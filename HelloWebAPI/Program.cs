using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

// Services (Container)
builder.Services.AddControllers(); // AddControllers() - MVC mimarisini kullanarak API geliştirmek için gerekli servisleri ekler
builder.Services.AddEndpointsApiExplorer(); // AddEndpointsApiExplorer() - API uç noktalarını keşfetmek ve belgelemek için gerekli servisleri ekler
builder.Services.AddSwaggerGen(); // AddSwaggerGen() - Swagger belgelerini oluşturmak için gerekli servisleri ekler

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
        app.UseSwagger(); // UseSwagger() - Swagger belgelerini oluşturur ve sunar
        app.UseSwaggerUI(); // UseSwaggerUI() - Swagger kullanıcı arayüzünü etkinleştirir, böylece API belgelerini görsel olarak inceleyebilir ve test edebilirsiniz
}


app.MapControllers(); // MapControllers() - Denetleyicileri (Controllers) uygulama rotalarına eşler, böylece gelen HTTP isteklerini uygun denetleyici eylemlerine yönlendirebilir

app.Run();
