using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPelicula.Models
{
    public class Peliculas
    {

        [Key]

        public int Pelicula_Id { get; set; }

        public string Nombre { get; set; }

        public string Actor { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }
    }
}
