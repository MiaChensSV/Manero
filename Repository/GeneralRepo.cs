using Manero.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero.Repository
{
    public abstract class GeneralRepo<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        protected GeneralRepo(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var _entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return _entity!;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var _entity = await GetAsync(expression);
                _context.Set<TEntity>().Remove(_entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { }
            return false;

        }

        public virtual async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression)
        {
            var _entity = await GetAsync(expression);
            _context.Set<TEntity>().Update(_entity);
            await _context.SaveChangesAsync();
            return _entity;
        }
    }
}
