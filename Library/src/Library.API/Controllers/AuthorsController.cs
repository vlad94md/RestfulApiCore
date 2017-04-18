using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    public class AuthorsController : Controller
    {
        private ILibraryRepository repository;

        public AuthorsController(ILibraryRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult GetAuthors()
        {
            var authors = repository.GetAuthors();

            return new JsonResult(authors);
        }
    }
}
