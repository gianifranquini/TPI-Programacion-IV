using AppleStore.Application.Interfaces;
using AppleStore.Application.Services;
using AppleStore.Infrastructure.Persistence;
using AppleStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Services
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<DetallePedidoService>();
builder.Services.AddScoped<UsuarioService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();