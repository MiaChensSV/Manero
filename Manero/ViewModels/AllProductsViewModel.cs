using Manero.Models.Dtos;

namespace Manero.ViewModels
{
    public class AllProductsViewModel
    {
        public string Title { get; set; } = null!;
        public IEnumerable<Product> AllProducts { get; set; } = new List<Product>();
    }
}
