using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class PrestamosContext : DbContext
    {
        public PrestamosContext(DbContextOptions options): base(options) { }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Libro)
                .WithMany(l => l.Prestamos)
                .HasForeignKey(p => p.IdLibro);

            modelBuilder.Entity<Prestamo>( e =>
            {
                e.HasKey(p => p.IdPrestamo);

                e.HasOne(l => l.Libro)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(l => l.IdLibro)
                    .IsRequired(false);

                e.HasOne(u => u.Usuario)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(u => u.IdUsuario);
            });
        }
    }
}
