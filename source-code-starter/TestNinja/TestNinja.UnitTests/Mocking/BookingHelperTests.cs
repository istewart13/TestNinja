using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Booking _booking;
        private Mock<IBookingStorage> _mockBookingStorage;

        [SetUp]
        public void Setup()
        {
            _booking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a"
            };

            _mockBookingStorage = new Mock<IBookingStorage>();

            _mockBookingStorage.Setup(bs => bs.GetBookings(1)).Returns(new List<Booking>
            {
                _booking
            }.AsQueryable());
        }

        [Test]
        public void OverlappingBookingsExist_BookingStatusOfCancelled_ReturnsEmptyString()
        {

        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishesBeforeAnExistingBooking_ReturnsEmptyString()
        {
            var booking = new Booking {
                Id = 1,
                ArrivalDate = ArriveOn(2017, 1, 21),
                DepartureDate = DepartOn(2017, 1, 28)
            };
            var result = BookingHelper.OverlappingBookingsExist(booking, _mockBookingStorage.Object);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishesAfterAnExistingBooking_ReturnsEmptyString()
        {

        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsBeforeButFinishesAfterAnExistingBooking_ReturnsOverlappedBookingReference()
        {

        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsBeforeFinishesDuringAnExistingBooking_ReturnsOverlappedBookingReference()
        {

        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsDuringAnExistingBooking_ReturnsOverlappedBookingReference()
        {

        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
