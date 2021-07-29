using System;
using System.Threading.Tasks;

namespace RESTfulBookingAPI.interfaces
{
    interface IUnitOfWork : IDisposable 
    {
        Task<int> Commet();
    }
}
