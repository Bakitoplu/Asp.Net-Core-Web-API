using Microsoft.AspNetCore.Mvc; // Microsoft.AspNetCore.Mvc - ASP.NET Core MVC framework'ünün temel bileşenlerini içeren bir isim alanıdır. Bu isim alanı, denetleyiciler (Controllers), eylemler (Actions), model bağlama (Model Binding) ve diğer MVC özelliklerini sağlar.
using HelloWebAPI.Models; // HelloWebAPI.Models - Projenin Models klasöründe bulunan sınıfları içeren bir isim alanıdır. Bu isim alanı, API'nin veri modellerini tanımlamak için kullanılır. Örneğin, ResponseModel sınıfı bu isim alanında tanımlanmıştır ve API'nin döndüreceği yanıtın yapısını belirler.

namespace HelloWebAPI.Controllers // HelloWebAPI.Controllers - Projenin Controllers klasöründe bulunan sınıfları içeren bir isim alanıdır. Bu isim alanı, API'nin denetleyicilerini tanımlamak için kullanılır. Denetleyiciler, gelen HTTP isteklerini işleyen ve uygun yanıtları döndüren sınıflardır. Örneğin, HomeController sınıfı bu isim alanında tanımlanmıştır ve API'nin ana denetleyicisi olarak görev yapar.
{
        [ApiController] // [ApiController] - Bu öznitelik, sınıfın bir API denetleyicisi olduğunu belirtir. Bu öznitelik, model doğrulama, otomatik HTTP 400 yanıtları ve diğer API özelliklerini etkinleştirir.
        [Route("home")] // [Route("home")] - Bu öznitelik, denetleyicinin temel rotasını belirtir. Bu durumda, denetleyici "home" rotasına atanır, yani API'ye "home" rotası üzerinden erişilebilir.
        public class HomeController : ControllerBase // HomeController - API'nin ana denetleyicisi olarak görev yapan bir sınıftır. Bu sınıf, gelen HTTP isteklerini işleyen ve uygun yanıtları döndüren eylem yöntemlerini içerir. ControllerBase sınıfından türetilmiştir, bu da temel denetleyici işlevselliğini sağlar ancak görünüm desteği içermez, çünkü bu bir Web API'dir.
        {
                [HttpGet] // [HttpGet] - Bu öznitelik, eylem yönteminin HTTP GET isteklerini işlediğini belirtir. Bu durumda, GetMessage() yöntemi "home" rotasına yapılan GET isteklerine yanıt verecektir.
                public IActionResult GetMessage() // GetMessage() - Bu eylem yöntemi, "home" rotasına yapılan GET isteklerine yanıt verir. Bu yöntem, bir ResponseModel nesnesi oluşturur ve bu nesneyi HTTP 200 OK yanıtıyla birlikte döndürür. IActionResult türü, farklı türde HTTP yanıtlarını döndürebilme esnekliği sağlar.
                {
                        var response = new ResponseModel // ResponseModel sınıfından bir nesne oluşturur. Bu sınıf, API'nin döndüreceği yanıtın yapısını belirler ve HttpStatus ve Message gibi özelliklere sahiptir.
                        {
                                HttpStatus = "200", // HttpStatus özelliği, yanıtın HTTP durum kodunu belirtir. Bu durumda, "200" değeri, isteğin başarılı olduğunu gösterir.
                                Message = "Hello ASP.NET Core Web API!" // Message özelliği, yanıtın içeriğini belirtir. Bu durumda, "Hello ASP.NET Core Web API!" değeri, API'nin döndüreceği mesajı içerir.
                        };
                        return Ok(response); // Ok() yöntemi, HTTP 200 OK yanıtı oluşturur ve içine verilen nesneyi (response) yanıt gövdesine ekler. Bu, API'nin başarılı bir şekilde işlendiğini ve response nesnesinin istemciye gönderildiğini gösterir.
                }
        }
    
}
