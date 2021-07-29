using RESTfulBookingAPI.interfaces;
using RESTfulBookingAPI.Models.Domain;
using System.Threading.Tasks;

namespace RESTfulBookingAPI.Models
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BookingContext context;
        public UnitOfWork(BookingContext context)
        {
            this.context = context;
            Reservation = new GUIDRepository<Reservation>(context);
            Trip = new GUIDRepository<Trip>(context);
            User = new GUIDRepository<User>(context);
        }

        public GUIDRepository<Reservation> Reservation { get; private set; }
        public GUIDRepository<Trip> Trip { get; private set; }
        public GUIDRepository<User> User { get; private set; }

        public async Task<int> Commet() => await context.SaveChangesAsync();

        public void Dispose() => context.Dispose();
    }
}
