using Manero.Repository;
using Manero.ViewModels;
using Newtonsoft.Json;


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
                    // Get the cart
                    var cart = GetCartFromSession();
                    
                        // Add the articlenumber (testade med id men då funka det inte :()
                        cart.Add(product.ArticleNumber);
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
            // Gets the cart from the session
            var cartProductArticleNumbers = GetCartFromSession();
            var productDetailsList = new List<CartViewModel>();

            // hämtar produkterna från databasen? 
            foreach (var articleNumber in cartProductArticleNumbers)
            {
                // Retrieve the product from the database
                var product = await _cartRepo.GetAsync(p => p.ArticleNumber == articleNumber);
                if (product != null)
                {
                    // Map the product entity to the CartViewModel
                    productDetailsList.Add(new CartViewModel
                    {
                        ArticleNumber = product.ArticleNumber,
                        ProductName = product.ProductTitle,
                        Size = product.Size?.SizeName, 
                        Color = product.Color?.ColorName, 
                        Price = product.Price,
                        Image = product.ProductImageUrl
                    });
                }
            }

            return productDetailsList;
        }


        private List<string> GetCartFromSession()
        {
            var cartItemsJson = _httpContextAccessor.HttpContext?.Session.GetString(SessionKeyCartItems);
            if (!string.IsNullOrEmpty(cartItemsJson))
            {
                return JsonConvert.DeserializeObject<List<string>>(cartItemsJson) ?? null! ;
            }

            return new List<string>();
        }

        private void SaveCartToSession(List<string> cart)
        {
            var cartItemsJson = JsonConvert.SerializeObject(cart);
            _httpContextAccessor.HttpContext?.Session.SetString(SessionKeyCartItems, cartItemsJson);
        }

    }
}

