﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Migrations
{
    [DbContext(typeof(PrestamosContext))]
    [Migration("20250417042705_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Libro", b =>
                {
                    b.Property<Guid>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponible")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLibro");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Dominio.Prestamo", b =>
                {
                    b.Property<Guid>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Devolucion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Prestamo")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IdLibro")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdPrestamo");

                    b.HasIndex("IdLibro");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Dominio.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Dominio.Prestamo", b =>
                {
                    b.HasOne("Dominio.Libro", "Libro")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdLibro");

                    b.HasOne("Dominio.Usuario", "Usuario")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Libro", b =>
                {
                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("Dominio.Usuario", b =>
                {
                    b.Navigation("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
