using Microsoft.EntityFrameworkCore;
using Target1.Areas.Identity.Data;
using Target1.Repository.IRepository;
using System.Linq.Expressions;
using System.Linq;

namespace Target1.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;

            //_db.ShopAffer.Include(u => u.ELProducts).Include(u => u.Brand.Name);
            //_db.ShopAffer.Include(x => x.Brand.Name);
            
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (Filter != null)
            {
                query = query.Where(Filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                   query = query.Include(property);
                }
            }
            return query.ToList();
        }

        public T GetFirstorDefult(Expression<Func<T, bool>>? Filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(Filter);
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
