using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class BookingStorage : IBookingStorage
    {
        private UnitOfWork _unitOfWork;

        public BookingStorage()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IQueryable<Booking> GetBookings(int excludedBookingId)
        {
            return _unitOfWork.Query<Booking>()
                .Where(
                b => b.Id != excludedBookingId && b.Status != "Cancelled");
        }
    }
}
