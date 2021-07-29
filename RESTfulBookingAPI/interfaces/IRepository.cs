using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTfulBookingAPI.interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<IEnumerable<T>> All();

        Task<T> GetId(int Id);

        IQueryable<T> Where(Expression<Func<T,bool>> expression);

    }
}
