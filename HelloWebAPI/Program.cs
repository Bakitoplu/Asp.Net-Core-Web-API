using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

// Services (Container)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.Run();
