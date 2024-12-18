using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projectef.Models
{
    public class Categoria
    {
        //[Key]
        public Guid CategoriID {get;set;}
        //[Required]
        //[MaxLength(150)]
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public int Peso {get;set;}
        public virtual ICollection<Tarea> Tareas {get;set;}
        public Guid CategoriaId { get; internal set; }
    }
}