using Microsoft.AspNetCore.Mvc; // API denetleyicileri için gerekli olan Microsoft.AspNetCore.Mvc ad alanını ekleyin.
using Microsoft.AspNetCore.Http;
using ProductApp.Models; // Product modelini kullanmak için ProductApp.Models ad alanını ekleyin.
using Microsoft.AspNetCore.Mvc.Formatters; // API denetleyicileri için gerekli olan Microsoft.AspNetCore.Http ad alanını ekleyin.

namespace ProductApp.Controllers // API denetleyicileri için Controllers klasöründe bir ProductsController sınıfı oluşturun.
{
    [ApiController] // Bu sınıfın bir API denetleyicisi olduğunu belirtmek için ApiController özniteliğini kullanın.
    [Route("api/products")] // Bu denetleyicinin URL'sinin "api/products" olduğunu belirtmek için Route özniteliğini kullanın.
    public class ProductsController : ControllerBase // API denetleyicileri için ControllerBase'den miras alın.
    {
        private readonly ILogger<ProductsController> _logger; // Logger'ı tanımlayın.
        public ProductsController(ILogger<ProductsController> logger) // Logger'ı yapıcı yönteme ekleyin.
        {
            _logger = logger; // Logger'ı sınıf düzeyinde kullanmak üzere atayın.
        }
        [HttpGet] // Bu yöntemin HTTP GET isteği olduğunu belirtmek için HttpGet özniteliğini kullanın.
        public IActionResult GetAllProducts() // Ürünleri almak için bir yöntem oluşturun.
        {
            var products = new List<Product> // Örnek ürünler oluşturun.
            {
                new Product { Id = 1, ProductName = "Computer" },
                new Product { Id = 2, ProductName = "Keyboard" },
                new Product { Id = 3, ProductName = "Mouse" }
            };
            _logger.LogInformation("GetAllProducts method called."); // Yöntemin çağrıldığını loglayın.
            return Ok(products); // Ürünleri döndürmek için Ok() yöntemini kullanın
    }
        [HttpPost] // Bu yöntemin HTTP POST isteği olduğunu belirtmek için HttpPost özniteliğini kullanın.
        public IActionResult CreateProduct([FromBody] Product product) // Yeni bir ürün oluşturmak için bir yöntem oluşturun ve ürün verilerini gövdeden alın.
        {
            _logger.LogWarning("Product has been created."); // Yeni bir ürün oluşturulduğunu loglayın.
            return StatusCode(201); // Oluşturulan ürünü döndürmek için StatusCode() yöntemini kullanın.
    }
        }
}