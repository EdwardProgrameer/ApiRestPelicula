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

    public class ActoresController : ControllerBase
    {

        private readonly ActoresRepositorio actoresRepositorio;

        public ActoresController()
        {
            actoresRepositorio = new ActoresRepositorio();
        }

        /// GET ALL

        [HttpGet]
        [Route("Get")]

        public IEnumerable<Actores> GetAll()
        {
            return actoresRepositorio.GetAll();
        }

        ///Get by Id 

        [HttpGet]
        [Route("Get/{id}")]

        public Actores GetById(int id)
        {
            return actoresRepositorio.GetById(id);
        }

        //INSERT 

        [HttpPost]
        public void Post([FromBody] Actores actores)
        {
            if (ModelState.IsValid)
                actoresRepositorio.Add(actores);
        }

        //UPDATE 

        [HttpPut("({id}")]
        public void Put (int id, [FromBody] Actores actores)
        {
        actores.Actor_Id = id;

            if (ModelState.IsValid)
                actoresRepositorio.update(actores);
        }

       //DELETE 

        [HttpDelete]

        public void Delete (int id)
        {
            actoresRepositorio.Delete(id);
        }
    }
}
