using Manero.Models.Entities;
using Manero.Models.Repository;
using Manero.ViewModels;
using Newtonsoft.Json;
using Stripe.Identity;

namespace Manero.Services
{
    public class CartService
    {
        private readonly CartRepo _cartRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string SessionKeyCartItems = "CartItems";

        public CartService(CartRepo cartRepo, IHttpContextAccessor httpContextAccessor)
        {
            _cartRepo = cartRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddToCart(string articleNumber)
        {
            try
            {
                var product = await _cartRepo.GetAsync(p => p.ArticleNumber == articleNumber);

                if (product != null)
                {
                    // Get current cart from the session
                    var cart = GetCartFromSession();

                    // Assuming the product ID is what you store in the cart
                    var productId = product.ProductId;


                    cart.Add(productId);
                    SaveCartToSession(cart);


                    return true;
                }
                else
                {
                    // Product not found
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                return false;
            }
        }
        public async Task<List<CartViewModel>> GetCartProductDetailsAsync()
        {
            // Assuming GetCartFromSession returns a List of product IDs (ArticleNumbers)
            var cartProductArticleNumbers = GetCartFromSession();
            var productDetailsList = new List<CartViewModel>();

            // You need to retrieve each product from the database based on the ArticleNumber
            foreach (var productId in cartProductArticleNumbers)
            {
                // Retrieve the product from the database
                var product = await _cartRepo.GetAsync(p => p.ProductId == productId);
                if (product != null)
                {
                    // Map the product entity to the CartViewModel
                    productDetailsList.Add(new CartViewModel
                    {
                        ArticleNumber = product.ArticleNumber,
                        ProductName = product.ProductTitle,
                        Size = product.Size?.SizeName, // Assuming Size is an entity with a Name property
                        Color = product.Color?.ColorName, // Assuming Color is an entity with a Name property
                        Price = product.Price,
                        Image = product.ProductImageUrl
                    });
                }
            }

            return productDetailsList;
        }


        private List<int> GetCartFromSession()
        {
            var cartItemsJson = _httpContextAccessor.HttpContext?.Session.GetString(SessionKeyCartItems);
            if (!string.IsNullOrEmpty(cartItemsJson))
            {
                return JsonConvert.DeserializeObject<List<int>>(cartItemsJson);
            }
            return new List<int>();
        }

        private void SaveCartToSession(List<int> cart)
        {
            var cartItemsJson = JsonConvert.SerializeObject(cart);
            _httpContextAccessor.HttpContext?.Session.SetString(SessionKeyCartItems, cartItemsJson);
        }

    }
}
