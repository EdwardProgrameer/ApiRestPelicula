using ApiRestPelicula.helper;
using ApiRestPelicula.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace ApiRestPelicula.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ApplicationDbContext applicationDbContext;
        private readonly IConfiguration conf;
        public LoginController(ApplicationDbContext applicationDbContext, IConfiguration config)
        {
            this.applicationDbContext = applicationDbContext;
            this.conf = config;
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        //funcion para login
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(HelpError.GetModelStateErrors(ModelState));
            }
            var user = await applicationDbContext.Usuarios.Where(x => x.Usuario_Id == login.Usuario_Id).SingleOrDefaultAsync();
            if (user == null)
            {
                return NotFound(new { error = true, message = "Este usuario no existe" });
            }
            string verify_password = HelpEncryptor.ConvertToDescrypt(user.Password_ID);
            if (verify_password != login.Password_ID)
            {
                return NotFound(new { error = true, message = "El usuario o el password es incorrecto" });
            }
            //creacio de token//

            string secret = this.conf.GetValue<string>("SecretKey");
            var HelpJwt = new HelpJwt(secret);
            string token = HelpJwt.CreateToken(user.Nombre);
            var response = new Responser
            {
                Usuario_Id = user.Usuario_Id,
                Nombre = user.Nombre,
                Apellido = user.Apellido
          
            };
            //Acceso por una hora //
            return StatusCode(200, new { error = false, message = "Ha accedido con exito", tokens = token, users = response });
        }
    }
}
