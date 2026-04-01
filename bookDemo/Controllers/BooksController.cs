using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bookDemo.Models;
using bookDemo.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }
        [HttpGet("{id:int}")] // Burada bir giriş alabilmesi için ıd değeri ekliyoruz
        public IActionResult GetOneBooks([FromRoute(Name = "id")]int id) // Bilginin Route'dan geleceğini belirtiyoruz

        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id)) // Id == girilen id ise sonuç döndür
                .SingleOrDefault(); // Tek değer gelsin gelmiyorsa Null
            if(book is null)
                return NotFound(); // Eğer null gelirse 404 kodu döndürsün

            return Ok(book);
        }
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book) // Bilgi Requestin body'sinden geliyor
        {
            try
            {
                if (book is null)
                    return BadRequest();  //400
                ApplicationContext.Books.Add(book);
                    return StatusCode(201, book);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut ("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")]int id,
        [FromBody] Book book)
        {
            // check book
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));

            if(entity is null)
                return NotFound(); // 404

            // check id
            if(id != book.Id)
                return BadRequest(); // 400

            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }
        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
             ApplicationContext.Books.Clear();
                return NoContent(); // 204
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound(new
                {
                    statusCode = 404, 
                    message = $"Book with id:{id} could not found"
                }); //404
            ApplicationContext.Books.Remove(entity);
            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")]int id, 
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            // check entity
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound(); // 404
            bookPatch.ApplyTo(entity);
             return NoContent (); //204
        }
    }
}