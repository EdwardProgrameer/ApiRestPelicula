using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPelicula.Models
{

    public class Actores
    {
        
        [Key]

        public int Actor_Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        


    }
}
