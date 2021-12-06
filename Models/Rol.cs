using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPelicula.Models
{
    public class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }

        public virtual ICollection<Usuarios> Usuarios
        {
            get; set;
        }
    }
}