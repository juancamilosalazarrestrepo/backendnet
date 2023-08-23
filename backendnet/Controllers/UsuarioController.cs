using backendnet.Domain.IServices;
using backendnet.Domain.Models;
using backendnet.DTO;
using backendnet.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backendnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioServices;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioServices = usuarioService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {

            try
            {
                var validateExistence = await _usuarioServices.ValidateExistence(usuario);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El usuario " + usuario.NombreUsuario + " Ya existe" });
                }
                usuario.Password=Encriptar.EncriptarPassword(usuario.Password);
                 await _usuarioServices.SaveUser(usuario);
                return Ok(new { message = "Usuario Registrado con exito" });

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //localhost:xxx/api/Usuario/CambiarPassword
        [Route("CambiarPassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPassword)
        {

            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);
                string PasswordEncriptado = Encriptar.EncriptarPassword(cambiarPassword.passwordAnterior);
                var usuario = await _usuarioServices.ValidatePassword(idUsuario, PasswordEncriptado);
                if (usuario == null)
                {
                    return BadRequest(new { message = "La password es incorrecta" });
                }
                else
                {
                    usuario.Password = Encriptar.EncriptarPassword(cambiarPassword.nuevaPassword);
                    await _usuarioServices.UpdatePassword(usuario);
                    return Ok(new { message = "La Password fue actualizada con exito" });
                }
                

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
