using AppleStore.Application.Interfaces;
using AppleStore.Application.Services;
using AppleStore.Infrastructure.Persistence;
using AppleStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Obtiene la clave secreta configurada en appsettings.json
var jwtKey = builder.Configuration["Jwt:Key"];

// Configuración de autenticación usando JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Parámetros que se usarán para validar el token recibido
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                // Verifica que el emisor del token sea válido
                ValidateIssuer = true,

                // Verifica que el destinatario del token sea válido
                ValidateAudience = true,

                // Verifica que el token no esté vencido
                ValidateLifetime = true,

                // Verifica que la firma del token sea correcta
                ValidateIssuerSigningKey = true,

                // Emisor esperado del token
                ValidIssuer = builder.Configuration["Jwt:Issuer"],

                // Destinatario esperado del token
                ValidAudience = builder.Configuration["Jwt:Audience"],

                // Clave utilizada para validar la firma del token
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
    client.BaseAddress =
        new Uri("https://dolarapi.com/");
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        }));

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();