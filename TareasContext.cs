using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias {get;set;}
        public DbSet<Tarea> Tareas {get;set;}
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CREANDO LA COLECCION DE NUEVOS REGISTROS MANUALMENTE
            List<Categoria> categoriaInit = new List<Categoria>();
            categoriaInit.Add(new Categoria(){ CategoriaId = Guid.Parse("429e610a-0a26-4790-9de3-58be1f6c0828"), Nombre="Actividades Pendientes", Peso = 20});
            categoriaInit.Add(new Categoria(){ CategoriaId = Guid.Parse("429e610a-0a26-4790-9de3-58be1f6c0802"), Nombre="Actividades Personales", Peso = 50});
            
            modelBuilder.Entity<Categoria>(categoria => 
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p => p.Peso);

                //AGREGANDO DATOS
                categoria.HasData(categoriaInit);
            });

            //CREANDO LA COLECCION DE NUEVOS REGISTROS MANUALMENTE
            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea () {TareaId = Guid.Parse("429e610a-0a26-4790-9de3-58be1f6c08B7"), CategoriaId = Guid.Parse("429e610a-0a26-4790-9de3-58be1f6c0828"), PrioridadTarea = Prioridad.Media, Titulo = "Revisar pago servicios publicos", FechaCreacion = DateTime.Now, Autor = "Maycol"});
            tareasInit.Add(new Tarea () {TareaId = Guid.Parse("429e610a-0a26-4790-9de3-58be1f6c0844"), CategoriaId = Guid.Parse("429e610a-0a26-4790-9de3-58be1f6c0802"), PrioridadTarea = Prioridad.Alta, Titulo = "Salir con amigos", FechaCreacion = DateTime.Now, Autor = "Maycol"});

            modelBuilder.Entity<Tarea>(tarea => 
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Autor).IsRequired().HasMaxLength(50);
                tarea.Property(p => p.Descripcion).IsRequired(false);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.Ignore(p => p.Resumen);

                //AGREGANDO DATOS
                tarea.HasData(tareasInit);
            });
        }
    }
}