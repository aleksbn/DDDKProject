using DDDKHostAPI.Models;
using System.Linq.Expressions;

namespace DDDKHostAPI.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        //2.3.3 Dodajemo genericke metode za CRUD operacije
        Task<IList<T>> GetAll(Expression<Func<T, bool>>? expression = null,
                              Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                              List<string>? includes = null, 
                              //6.1.3 Ovaj poslednji parametar se dodaje kod paginacije
                              RequestParams? requestParams = null);

        Task<T> Get(Expression<Func<T, bool>> expression, List<string>? includes = null);

        Task Insert(T entity);

        Task InsertRange(IEnumerable<T> entities);

        Task Delete(int id);

        void DeleteRange(IEnumerable<T> entities);

        void Update(T entity);
    }
}
