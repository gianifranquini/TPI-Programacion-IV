using AppleStore.Application.Interfaces;
using AppleStore.Application.Services;
using AppleStore.Infrastructure.Persistence;
using AppleStore.Infrastructure.Repositories;
using AppleStore.Domain.Entities;
using AppleStore.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// JWT
var jwtKey = builder.Configuration["Jwt:Key"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtKey!))
            };
    });

// Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Services
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<DetallePedidoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DolarService>();

builder.Services.AddHttpClient<DolarService>(client =>
{
    client.BaseAddress = new Uri("https://dolarapi.com/");
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var userService = scope.ServiceProvider.GetRequiredService<UsuarioService>();

    var adminExists = await db.Usuarios
        .AnyAsync(u => u.Nombre == "admin@applestore.com");

    if (!adminExists)
    {
        var admin = new Usuario
        {
            Nombre = "admin@applestore.com",
            Contrasenia = "admin123",
            Rol = Rol.Admin
        };

        await userService.Create(admin);
    }
}

// Middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();