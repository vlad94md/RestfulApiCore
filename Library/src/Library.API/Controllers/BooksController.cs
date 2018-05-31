using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/authors/{authorid}/books")]
    public class BooksController : Controller
    {
        private ILibraryRepository repository;

        public BooksController(ILibraryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public IActionResult GetBooksForAuthor(Guid authorid)
        {
            var author = repository.GetAuthor(authorid);

            if (author == null)
            {
                return NotFound();
            }

            var authorBooks = repository.GetBooksForAuthor(authorid);

            return Ok(Mapper.Map<IEnumerable<BookDto>>(authorBooks));
        }

        [HttpGet("{id}")]
        public IActionResult GetBookForAuthor(Guid authorId, Guid id)
        {
            if (repository.AuthorExists(authorId) == false)
            {
                return NotFound();
            }

            var bookForAuthor = repository.GetBookForAuthor(authorId, id);

            if (bookForAuthor == null)
            {
                return NotFound();
            }
            return Ok(bookForAuthor);
        }
    }
}
