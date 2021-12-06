using ApiRestPelicula.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPelicula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {

        private readonly PeliculasRepositorio pelicularepositorio;

        public PeliculaController()
        {
            pelicularepositorio = new PeliculasRepositorio();
        }

        // GET ALL

        [HttpGet]
        [Route("Get")]

        public IEnumerable<Peliculas> GetAll()
        {
            return pelicularepositorio.GetAll();
        }

        //Get by Id 

        [HttpGet]
        [Route("Get/{id}")]

        public Peliculas GetById(int id)
        {
            return pelicularepositorio.GetById(id);
        }

        //INSERT 

        [HttpPost]
        public void Post([FromBody] Peliculas peliculas)
        {
            if (ModelState.IsValid)
                pelicularepositorio.Add(peliculas);
        }

        //UPDATE 

        [HttpPut("({id}")]
        public void Put(int id, [FromBody] Peliculas peliculas)
        {
            peliculas.Pelicula_Id = id;

            if (ModelState.IsValid)
                pelicularepositorio.update(peliculas);
        }

        //DELETE 

        [HttpDelete]

        public void Delete(int id)
        {
            pelicularepositorio.Delete(id);
        }

    }
}
