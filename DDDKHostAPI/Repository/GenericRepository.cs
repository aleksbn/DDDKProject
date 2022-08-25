using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models;
using DDDKHostAPI.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DDDKHostAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly DatabaseContext _databaseContext;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _db = _databaseContext.Set<T>();
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            if (entity != null)
                _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>>? expression = null, List<string>? includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<string>? includes = null, RequestParams? requestParams = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            IList<T> toReturn = await query.AsNoTracking().ToListAsync();
            if (requestParams != null)
            {
                toReturn = toReturn.Skip((requestParams.PageNumber - 1) * requestParams.PageSize).Take(requestParams.PageSize).ToList();
            }
            return toReturn;
        }

       public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _databaseContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
