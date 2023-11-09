using Manero.Models.Entities;

namespace Manero.ViewModels
{
    public class CartViewModel
    {
        
        public string? ArticleNumber { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get;set; }
        public List<OrderDetailEntity> OrderDetails { get; set; }=new List<OrderDetailEntity>();
    }
}
