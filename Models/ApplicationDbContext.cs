using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPelicula.Models
{
    public class ApplicationDbContext
    {
        public virtual DbSet<Actores> Actores { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Peliculas> Peliculas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }

    }
}
