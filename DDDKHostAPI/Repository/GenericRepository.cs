using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models;
using DDDKHostAPI.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DDDKHostAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        //2.3.4 Pravimo 2 privatna polja koja sluze tome da se ova klasa ne mora instancirati svaki put kad nam ustreba
        private readonly DatabaseContext _databaseContext;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext databaseContext)
        {
            //databaseContext je instancirana u Program.cs fajlu
            _databaseContext = databaseContext;
            //Tip T iz ove komande je bilo koji DbSet iz klase DatabaseContext 
            _db = _databaseContext.Set<T>();
        }

        //2.3.5 Pisanje svih metoda naslijedjenih iz IGenericRepository
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

        public async Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
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
        //6.1.4 Dodajemo requestParams da bi paginacija radila
        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null, RequestParams requestParams = null)
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
