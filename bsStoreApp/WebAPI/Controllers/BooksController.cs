using System.Data;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Repositories.Contracts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepositoryManager _manager;

        public BooksController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
              try
            {
                var books = _manager.Book.GetAllBooks(false);
            return Ok(books); 

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message); 
            }
            
        }
        [HttpGet("{id:int}")] // Burada bir giriş alabilmesi için ıd değeri ekliyoruz
        public IActionResult GetOneBooks([FromRoute(Name = "id")]int id) // Bilginin Route'dan geleceğini belirtiyoruz

        {
            try
            {
                var book = _manager
                .Book
                .GetOneBooksById(id,false);
                if (book is null)
                return NotFound(); // Eğer null gelirse 404 kodu döndürsün

            return Ok(book);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message); 
            }
            
        }
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book) // Bilgi Requestin body'sinden geliyor
        {
            try
            {
                if (book is null)
                    return BadRequest();  //400
                _manager.Book.CreateOneBook(book);
                _manager.Save();
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
            try
            {
                // check book
            var entity = _manager
                .Book
                .GetOneBooksById(id,true );
                
            if(entity is null)
                return NotFound(); // 404

            // check id
            if(id != book.Id)
                return BadRequest(); // 400

            entity.Title = book.Title; 
            entity.Price = book.Price; 

            _manager.Save();
            return Ok(book);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _manager
                .Book
                .GetOneBooksById(id,true);
                if (entity is null)
                return NotFound(new
                {
                    statusCode = 404, 
                    message = $"Book with id:{id} could not found"
                }); //404
            _manager.Book.DeleteOneBook(entity);
            _manager.Save();
            return NoContent();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")]int id, 
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            // check entity
            var entity = _manager.Book.GetOneBooksById(id,true);
            if (entity is null)
                return NotFound(); // 404
            bookPatch.ApplyTo(entity);
            _manager.Book.Update(entity);
             return NoContent (); //204
        }
    }
}