using System.Data;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _context;
        
        public BooksController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
              try
            {
                var books = _context.Books.ToList();
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
                var book = _context
                .Books
                .Where(b => b.Id.Equals(id)) // Id == girilen id ise sonuç döndür
                .SingleOrDefault(); // Tek değer gelsin gelmiyorsa Null
            if(book is null)
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
                _context.Books.Add(book);
                _context.SaveChanges();
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
            var entity = _context
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();
            if(entity is null)
                return NotFound(); // 404

            // check id
            if(id != book.Id)
                return BadRequest(); // 400

            entity.Title = book.Title; 
            entity.Price = book.Price; 

            _context.SaveChanges();
            _context.Books.Add(book);
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
                var entity = _context
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();
                if (entity is null)
                return NotFound(new
                {
                    statusCode = 404, 
                    message = $"Book with id:{id} could not found"
                }); //404
            _context.Books.Remove(entity);
            _context.SaveChanges();
            return NoContent();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        
    }
}