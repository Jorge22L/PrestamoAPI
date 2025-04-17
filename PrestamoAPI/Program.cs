using Aplicacion.Interfaces;
using Aplicacion.Mappings;
using Aplicacion.Repositories;
using Aplicacion.Services;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PrestamosContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adding Repositories
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPrestamoRepository, PrestamoRepository>();

//Adding Services
builder.Services.AddScoped<LibroService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PrestamoService>();

builder.Services.AddAutoMapper(typeof(LibroProfile));
builder.Services.AddAutoMapper(typeof(UsuarioProfile));
builder.Services.AddAutoMapper(typeof(PrestamoProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsRule", rule =>
    {
        rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    try
    {
        await InitializeDatabaseAsync(app);
    }
    catch (Exception ex)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error durante la inicialización de la base de datos");
        throw; // Detiene la aplicación si hay error crítico
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsRule");

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task InitializeDatabaseAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<PrestamosContext>();

    if (!await context.Database.CanConnectAsync())
    {
        Console.WriteLine("La base de datos no existe o no se puede conectar. Creando...");
        await context.Database.MigrateAsync();
    }

    var hasData = await context.Libros.AnyAsync() ||
                 await context.Usuarios.AnyAsync();

    if (!hasData)
    {
        Console.WriteLine("Sembrando datos iniciales...");
        await using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            await Seed.SeedData(context);
            await transaction.CommitAsync();
            Console.WriteLine("Datos iniciales sembrados exitosamente");
        }
        catch
        {
            await transaction.RollbackAsync();
            Console.WriteLine("Error al sembrar datos. Revertiendo cambios...");
            throw;
        }
    }
    else
    {
        Console.WriteLine("Aplicando migraciones pendientes...");
        await context.Database.MigrateAsync();
    }
}