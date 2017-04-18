using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTimeApplication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookTimeApplication.Controllers
{
    public class BookingController : Controller
    {
        [HttpPost]
        public void CreateBooking(DateTime startDate, DateTime endDatate, string username)
        {
            var newBooking = new BookedSession() {StartDate = startDate, EndDate = endDatate, PersonUsername = username};

            DbContext.Bookings.Add(newBooking);
        }

        [HttpGet]
        public ICollection<BookedSession> GetBookings()
        {
            return DbContext.Bookings;
        }
    }
}
