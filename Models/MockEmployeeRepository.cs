
using DbHandson.Data;
using Microsoft.EntityFrameworkCore;

namespace DbHandson.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProductDbContext context;
        protected readonly DbSet<T> _dbSet;


        private async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public Repository(ProductDbContext context)
        {
            this.context = context;
            this._dbSet = context.Set<T>();
        }


       
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task AddAsync(T entity)
        {

            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();

        }

        public async Task DeleteAsync(T entity)
        {
             _dbSet.Remove(entity);
              await SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
             _dbSet.Update(entity);
            await SaveChangesAsync();
        }
    }
}
