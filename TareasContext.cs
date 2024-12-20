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
    }
}