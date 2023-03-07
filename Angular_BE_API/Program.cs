var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(cors =>
{
    cors.AddPolicy("angular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseCors("angular");
app.MapControllers();

app.Run();
