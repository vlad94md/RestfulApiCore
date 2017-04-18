using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTimeApplication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookTimeApplication.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ICollection<User> GetUsers()
        {
            return DbContext.Users;
        }
    }
}
