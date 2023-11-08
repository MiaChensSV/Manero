using Manero.Models.Dtos;
using Manero.Models.Entities;

namespace Manero.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDetailEntity Product { get; set; } = null!;
      

        public List<ReviewEntity> Reviews { get; set; } = null!;
    }
}
