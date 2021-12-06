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

    public class UsuarioController : ControllerBase 
    {
        private readonly UsuarioRepositorio usuarioRepositorio ;

        public UsuarioController()
        {
            usuarioRepositorio = new UsuarioRepositorio();
        }

        // GET ALL

        [HttpGet]
        [Route("Get")]

        public IEnumerable<Usuarios> GetAll()
        {
            return usuarioRepositorio.GetAll();
        }

        //Get by Id 

        [HttpGet]
        [Route("Get/{id}")]

        public Usuarios GetById(int id)
        {
            return usuarioRepositorio.GetById(id);
        }

        //INSERT 

        [HttpPost]
        public void Post([FromBody] Usuarios usuarios)
        {
            if (ModelState.IsValid)
                usuarioRepositorio.Add(usuarios);
        }

        //UPDATE 

        [HttpPut("({id}")]
        public void Put(int id, [FromBody] Usuarios usuarios)
        {
            usuarios.Usuario_Id = id;

            if (ModelState.IsValid)
               usuarioRepositorio.update(usuarios);
        }

        //DELETE 

        [HttpDelete]

        public void Delete(int id)
        {
            usuarioRepositorio.Delete(id);
        }
    }
}
