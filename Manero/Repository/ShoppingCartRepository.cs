using Manero.Context;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manero.Repository
{
    public class ShoppingCartRepository : GeneralRepo<OrderDetailEntity>
    {
        private readonly DataContext _context;

        public ShoppingCartRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateCartItemByUser(string userId, string artNum)
        {
            var product = _context.ProductDetail
                            .Where(row => row.ArticleNumber == artNum).FirstOrDefault();
            int _orderId = await GetOrderIdByUser(userId);
            OrderDetailEntity newCartItem = new()
            {
                OrderId = _orderId,
                ArticleNumber = artNum,
                Quantity = 1,
                Price = product.Price,
                DiscountedPrice = product.DiscountedPrice,

            };

            await _context.OrderDetail.AddAsync(newCartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderDetailEntity>> GetCartByUser(string userId)
        {
            int _orderId = GetOrderIdByUser(userId).Result;
            var _orderDetailList = await _context.OrderDetail
                .Include(row => row.Product)
                .ThenInclude(row => row.Size)
                .Include(row => row.Product)
                .ThenInclude(row => row.Color)
                .Where(row => row.OrderId == _orderId)
                .ToListAsync();
            return _orderDetailList;
        }

        public async Task UpdateCartByUser(OrderDetailEntity cartItem)
        {
            _context.OrderDetail.Update(cartItem);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCartItemByUser(OrderDetailEntity cartItem)
        {
            _context.OrderDetail.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        private async Task<int> GetOrderIdByUser(string userId)
        {
            var _orderDetails = await _context.OrderDetails
                .Where(row => row.UserId == userId)
                .Where(row => row.StatusId == 1)
                .OrderBy(row => row.Modified_Date)
                .LastOrDefaultAsync();
            if (_orderDetails != null)
                return _orderDetails.OrderId;
            else
            {
                OrderEntity _orderEntity = new()
                {
                    UserId = userId,
                    StatusId = 1,
                    ShippingAddress = "",
                    TrackingNumber = "",
                    DeliveryFee = 0,
                    TotalCost = 0,
                    PromocodeId = 1,
                };
                var orderId = await _context.OrderDetails.AddAsync(_orderEntity);
                await _context.SaveChangesAsync();
                return _orderEntity.OrderId;
            }
        }
    }
}