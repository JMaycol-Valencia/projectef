﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectef;

#nullable disable

namespace projectef.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20241218195028_FixColumsCategori")]
    partial class FixColumsCategori
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projectef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriID");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriID = new Guid("429e610a-0a26-4790-9de3-58be1f6c0828"),
                            Nombre = "Actividades Pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriID = new Guid("429e610a-0a26-4790-9de3-58be1f6c0802"),
                            Nombre = "Actividades Personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("projectef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("CategoriID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriID");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("429e610a-0a26-4790-9de3-58be1f6c08b7"),
                            Autor = "Maycol",
                            CategoriID = new Guid("429e610a-0a26-4790-9de3-58be1f6c0828"),
                            FechaCreacion = new DateTime(2024, 12, 18, 15, 50, 28, 321, DateTimeKind.Local).AddTicks(5372),
                            PrioridadTarea = 1,
                            Titulo = "Revisar pago servicios publicos"
                        },
                        new
                        {
                            TareaId = new Guid("429e610a-0a26-4790-9de3-58be1f6c0844"),
                            Autor = "Maycol",
                            CategoriID = new Guid("429e610a-0a26-4790-9de3-58be1f6c0802"),
                            FechaCreacion = new DateTime(2024, 12, 18, 15, 50, 28, 321, DateTimeKind.Local).AddTicks(5391),
                            PrioridadTarea = 2,
                            Titulo = "Salir con amigos"
                        });
                });

            modelBuilder.Entity("projectef.Models.Tarea", b =>
                {
                    b.HasOne("projectef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("projectef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}