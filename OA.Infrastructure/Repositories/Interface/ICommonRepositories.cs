using System.Linq.Expressions;

namespace OA.Infrastructure.Repositories.Interface
{
    public interface ICommonRepositories<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> List(Expression<Func<T, bool>> expression);
    }
}
