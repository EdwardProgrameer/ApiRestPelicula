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
    public class RolController : ControllerBase
    {
        private readonly RolRepositorio rolRepositorio ;

        public RolController()
        {
            rolRepositorio = new RolRepositorio();
        }

        // GET ALL

        [HttpGet]
        [Route("Get")]

        public IEnumerable<Rol> GetAll()
        {
            return rolRepositorio.GetAll();
        }

        //Get by Id 

        [HttpGet]
        [Route("Get/{id}")]

        public Rol GetById(int id)
        {
            return rolRepositorio.GetById(id);
        }

        //INSERT 

        [HttpPost]
        public void Post([FromBody] Rol rol)
        {
            if (ModelState.IsValid)
                rolRepositorio.Add(rol);
        }

        //UPDATE 

        [HttpPut("({id}")]
        public void Put(int id, [FromBody] Rol rol)
        {
            rol.Id = id;

            if (ModelState.IsValid)
                rolRepositorio.update(rol);
        }

        //DELETE 

        [HttpDelete]

        public void Delete(int id)
        {
            rolRepositorio.Delete(id);
        }
    }
}
