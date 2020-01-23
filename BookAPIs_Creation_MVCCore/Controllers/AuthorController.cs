using BookAPIs_Creation_MVCCore.DTO;
using BookAPIs_Creation_MVCCore.Serivces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController :Controller
    {
        private readonly IAuthoRepository authoRepository;
        private readonly IBookRepository bookRepository;

        public AuthorController(IAuthoRepository authoRepository, IBookRepository bookRepository)
        {
            this.authoRepository = authoRepository;
            this.bookRepository = bookRepository;
        }

        //api/author
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDTO>))]
        public IActionResult GetAuthors()
        {
            var authors = authoRepository.GetAuthors().ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var authorList = new List<AuthorDTO>();
            foreach (var item in authors)
            {
                authorList.Add(new AuthorDTO()
                {
                     FirstName=item.first_Name,
                      Id=item.id, 
                       LastName= item.last_NameW
                });
            }
            return Ok(authorList);
        }

        //api/author/authorid
        [HttpGet("{authorid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(AuthorDTO))]
        public IActionResult GetAuthor(int authorid)
        {
            var item = authoRepository.GetAuthor(authorid);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var model = new AuthorDTO
            {
                FirstName = item.first_Name,
                Id = item.id,
                LastName = item.last_NameW
            };
            return Ok(model);
        }

        //api/author/authorid/Books
        [HttpGet("{authorid}/books")]
        [ProducesResponseType(200,Type =typeof(IEnumerable<BookDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBookByAuthor(int authorid)
        {
            if(!authoRepository.AuthorExist(authorid))
            {
                return NotFound();
            }

            var books = authoRepository.GetBookByAuthor(authorid);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookDTo = new List<BookDTO>();

            foreach (var item in books)
            {
                bookDTo.Add(new BookDTO()
                {
                    Date_Published = item.date_Published,
                    Id = item.id,
                    Isbn = item.isbn,
                    Title = item.title
                });
            }

            return Ok(bookDTo);
        }

        //api/author/bokks/bookid
        [HttpGet("books/{bookid}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAuthorsBybook(int bookid)
        {
            if (!bookRepository.BookExist(bookid))
                return NotFound();
            var authors = authoRepository.GetAuthorOfBook(bookid);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var authorList = new List<AuthorDTO>();
            foreach (var item in authors)
            {
                authorList.Add(new AuthorDTO()
                {
                    FirstName = item.first_Name,
                    Id = item.id,
                    LastName = item.last_NameW
                });
            }
            return Ok(authorList);
        }


    }
}
