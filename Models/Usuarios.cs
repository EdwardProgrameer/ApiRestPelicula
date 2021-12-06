using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPelicula.Models
{
    public class Usuarios
    {
        [Key]

        public int Usuario_Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Password_ID { get; set; }

        public int IdRol { get; set; }

        public virtual Rol IdRolExp { get; set; }
    }
}
