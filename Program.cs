using Aplicacion.Mappings;
using Aplicacion.Repositories;
using Aplicacion.Services;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PrestamosContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adding Repositories
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

//Adding Services
builder.Services.AddScoped<LibroService>();

builder.Services.AddAutoMapper(typeof(LibroProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
