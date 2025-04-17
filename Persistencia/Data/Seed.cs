using Dominio;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;

namespace Persistence.Data;

public static class Seed
{
    public static async Task SeedData(PrestamosContext context)
    {
        // Evitar datos duplicados
        if (await context.Libros.AnyAsync() || await context.Usuarios.AnyAsync())
            return;

        // 1. Seed de Libros
        var libros = new List<Libro>
        {
            new Libro { IdLibro = Guid.NewGuid(), Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Disponible = true },
            new Libro { IdLibro = Guid.NewGuid(), Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", Disponible = true },
            new Libro { IdLibro = Guid.NewGuid(), Titulo = "1984", Autor = "George Orwell", Disponible = true }
        };
        await context.Libros.AddRangeAsync(libros);

        // 2. Seed de Usuarios
        var usuarios = new List<Usuario>
        {
            new Usuario { IdUsuario = Guid.NewGuid(), Nombre = "Juan", Apellido = "Pérez" , Email = "juan@example.com", Telefono = "+56912345678" },
            new Usuario { IdUsuario = Guid.NewGuid(), Nombre = "María", Apellido = "García", Email = "maria@example.com", Telefono = "+56987654321" }
        };
        await context.Usuarios.AddRangeAsync(usuarios);

        await context.SaveChangesAsync();

        // 3. Seed de Préstamos (opcional)
        var prestamos = new List<Prestamo>
        {
            new Prestamo
            {
                IdPrestamo = Guid.NewGuid(),
                IdLibro = libros[0].IdLibro,
                Libro = libros[0],
                IdUsuario = usuarios[0].IdUsuario,
                Usuario = usuarios[0],
                Fecha_Prestamo = DateTime.UtcNow.AddDays(-7),
                Fecha_Devolucion = DateTime.UtcNow.AddDays(7),
                Estado = "Activo"
            }
        };
        await context.Prestamos.AddRangeAsync(prestamos);
        await context.SaveChangesAsync();
    }
}