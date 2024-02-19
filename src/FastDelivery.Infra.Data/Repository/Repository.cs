using FastDelivery.Business;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FastDelivery.Infra.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly ApplicationContext Db;
        protected readonly DbSet<T> DbSet;

        protected Repository(ApplicationContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Add(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
