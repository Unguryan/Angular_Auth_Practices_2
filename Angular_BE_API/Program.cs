using Auth.App.Services;
using Auth.EF_Core.Context;
using Auth.EF_Core.Dbo;
using Auth.Infra;
using Microsoft.IdentityModel.Tokens;

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

builder.Services.AddEFCore();
builder.Services.AddInfra();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseCors("angular");
app.MapControllers();



using (var scope = app.Services.CreateScope())
{
    using (var db = scope.ServiceProvider.GetRequiredService<AuthContext>())
    {
        var service = scope.ServiceProvider.GetRequiredService<IEncodePasswordService>();
        await db.Database.EnsureCreatedAsync();
        if (!db.Users.Any(x => x.Email == "admin@admin.com"))
        {
            await db.Users.AddAsync(new UserDbo()
            {
                Email = "admin@admin.com",
                Name = "admin",
                Surname = "admin",
                Phone = "admin",
                PasswordHash = await service.EncodePasswordAsync("admin12345678")
            });

            await db.SaveChangesAsync();
        }
    }
}

app.Run();
