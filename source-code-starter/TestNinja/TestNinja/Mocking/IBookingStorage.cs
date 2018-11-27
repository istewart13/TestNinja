using System.Linq;

namespace TestNinja.Mocking
{
    public interface IBookingStorage
    {
        IQueryable<Booking> GetBookings(int excludedBookingId);
    }
}