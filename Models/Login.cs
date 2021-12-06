using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiRestPelicula.Models
{
    public class Login
    {
        [Key]

        [Required(ErrorMessage = "El campo Id es requerido")]
        public int Usuario_Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Password_ID { get; set; }
    }
}
