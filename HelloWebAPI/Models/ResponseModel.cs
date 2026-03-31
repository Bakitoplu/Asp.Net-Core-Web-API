namespace HelloWebAPI.Models // HelloWebAPI.Models - Projenin Models klasöründe bulunan sınıfları içeren bir isim alanıdır. Bu isim alanı, API'nin veri modellerini tanımlamak için kullanılır. Örneğin, ResponseModel sınıfı bu isim alanında tanımlanmıştır ve API'nin döndüreceği yanıtın yapısını belirler.
{
        public class ResponseModel // ResponseModel - API'nin döndüreceği yanıtın yapısını belirleyen bir sınıftır. Bu sınıf, HttpStatus ve Message gibi özelliklere sahiptir ve API'nin istemciye göndereceği yanıtın içeriğini tanımlar.
        {
                public string? HttpStatus { get; set; } // HttpStatus özelliği, yanıtın HTTP durum kodunu belirtir. Bu özellik, API'nin istemciye döndüreceği yanıtın durumunu göstermek için kullanılır. Örneğin, "200" değeri, isteğin başarılı olduğunu gösterir.
                public string? Message { get; set; } // Message özelliği, yanıtın içeriğini belirtir. Bu özellik, API'nin istemciye döndüreceği mesajı içermek için kullanılır. Örneğin, "Hello ASP.NET Core Web API!" değeri, API'nin döndüreceği mesajı içerir.
        }
    
}