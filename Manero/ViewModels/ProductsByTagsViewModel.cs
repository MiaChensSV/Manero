using Manero.Models.Dtos;

namespace Manero.ViewModels
{
    public class ProductsByTagsViewModel
    {

            public string? Title { get; set; } 
            public string? TagTitle { get; set; } 

            public IEnumerable<ProductProductList> ProductByTagName { get; set; } = new List<ProductProductList>();
            
        
    }
}
