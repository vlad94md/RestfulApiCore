using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookTimeApplication.Entities
{
    public static class DbContext
    {
        public static ICollection<User> Users;
        public static ICollection<BookedSession> Bookings;

        static DbContext()
        {
            Users = new List<User>();
            Bookings = new List<BookedSession>();

            //Add admins
            Users.Add(new User() { Password = "123", Username = "shady" });
            Users.Add(new User() { Password = "123", Username = "don" });
        }
    }
}
