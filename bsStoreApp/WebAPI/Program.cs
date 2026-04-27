using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;
using WebAPI.Extentions;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
                .AddNewtonsoftJson();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders(); // Mevcut tüm log sağlayıcılarını temizleyin
builder.Logging.AddConsole(); // Konsol log sağlayıcısını ekleyin
builder.Logging.AddDebug(); // Debug log sağlayıcısını ekleyin

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


// app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();