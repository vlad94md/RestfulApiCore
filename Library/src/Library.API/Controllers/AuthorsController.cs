using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Library.API.Entities;

namespace Library.API.Controllers
{
    [Route("/api/authors")]
    public class AuthorsController : Controller
    {
        private ILibraryRepository repository;

        public AuthorsController(ILibraryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsEntities = repository.GetAuthors();

            var authors = Mapper.Map<IEnumerable<AuthorDto>>(authorsEntities);
            return Ok(authors);
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetAuthor(Guid id)
        {
            var author = repository.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }

            var authorDto = Mapper.Map<AuthorDto>(author);
            return Ok(author);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorCreationDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            var authorEntity = Mapper.Map<Author>(author);

            repository.AddAuthor(authorEntity);

            if (!repository.Save())
            {
                throw new Exception("A problem happened with handling your request.");
            }

            var authorToReturn = Mapper.Map<AuthorDto>(authorEntity);

            return CreatedAtRoute("GetAuthor", new { id = authorToReturn.Id }, authorToReturn);
        }
    }
}
