using Microsoft.AspNetCore.Mvc;
using RESTbooks.Models;
using RESTbooks.Repos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTbooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookRepo _repo;
        public BooksController(BookRepo repo)
        {
            _repo = repo;
        }

        // GET: api/<BooksController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            IEnumerable<Book> result = _repo.GetAllBooks();
            //if (result == null || result.Any()) {
            //    return NoContent();
            //}
            return Ok(result);
        }

        // GET api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            Book? book = _repo.GetBookById(id);
            if (book == null)
            {
                return NoContent();
            }
            return Ok(book);
        }

        // POST api/<BooksController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book newBook)
        {
            try
            {
                _repo.AddBook(newBook);
                return Created($"api/books/{newBook.Id}", newBook);
            }
            catch (ArgumentException ex)
            {
                if (newBook.Title == null || newBook.Author == null || newBook.Price <= 0) ;
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book value)
        {
            Book? book = _repo.UpdateBook(id, value);
            if (book == null)
            {
                return NoContent();
            }
            return Ok(book);
        }

        // DELETE api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            Book? book = _repo.DeleteBook(id);
            if (book == null)
            {
                return NoContent();
            }
            return Ok(book);
        }

        public void Options() { }
    }
}
