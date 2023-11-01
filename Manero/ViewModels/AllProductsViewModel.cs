using Manero.Models.Dtos;

namespace Manero.ViewModels
{
    public class AllProductsViewModel
    {
        public string Title { get; set; } = null!;
        public IEnumerable<ProductProductList> AllProducts { get; set; } = new List<ProductProductList>();
        public IEnumerable<ReviewProductList> AllReviews { get; set; } = new List<ReviewProductList>(); 
    }
}
