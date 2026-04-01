var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddNewtonsoftJson();
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