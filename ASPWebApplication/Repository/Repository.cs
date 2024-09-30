using ASPWebApplication.Repository.IRepository;
using System.Linq.Expressions;

namespace ASPWebApplication.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        

        void IRepository<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }

        T IRepository<T>.Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Remove(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.RemoveRange(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
