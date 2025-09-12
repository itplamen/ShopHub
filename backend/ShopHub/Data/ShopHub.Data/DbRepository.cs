namespace ShopHub.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using ShopHub.Data.Contracts;
    using ShopHub.Data.Models.Contracts;

    public class DbRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ShopHubDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public DbRepository(ShopHubDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public IQueryable<TEntity> Filter() => dbSet;

        public async Task<TEntity> GetByIdAsync(int id) => await dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await dbSet.Where(x => !x.DeletedOn.HasValue).ToListAsync();

        public async Task AddAsync(TEntity item) => await dbSet.AddAsync(item);

        public void Update(TEntity item) => dbSet.Update(item);

        public void Delete(TEntity item)
        {
            item.DeletedOn = DateTime.UtcNow;
            dbSet.Update(item);  
        }

        public void HardDelete(TEntity item) => dbSet.Remove(item);

        public Task SaveChangesAsync() => context.SaveChangesAsync();
    }
}
