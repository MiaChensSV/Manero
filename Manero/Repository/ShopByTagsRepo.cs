using Manero.Context;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manero.Repository
{
    public class ShopByTagsRepo : GeneralRepo<ProductDetailEntity>
    {

        private readonly DataContext _dataContext;
        public ShopByTagsRepo(DataContext context, DataContext dataContext) : base(context)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<ProductDetailEntity>> GetAllAsync(string tagName)
        {
            var products = await _dataContext.ProductDetail
                .Include(b => b.ProductModel)
                .ThenInclude(p => p.Tags)
                .ThenInclude(p => p.Tag)
                 .Where(p => p.ProductModel.Tags.Any(t => t.Tag.TagName == tagName))



                .ToListAsync();

            return products;

        }

        /*
        public async Task<IEnumerable<ProductDetailEntity>> GetAllByTagNameAsync(string tagName)
        {
            var products = await _dataContext.ProductDetail
                .Include(b => b.ProductModel)
                .ThenInclude(p => p.Tags)
                .Where(p => p.Tags.Any(t => t.Tag.TagName == tagName))
                .ToListAsync();

            return products;
        }
        */
    }
}
