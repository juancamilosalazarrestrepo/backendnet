using backendnet.Domain.IServices;
using backendnet.Domain.Models;
using backendnet.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
