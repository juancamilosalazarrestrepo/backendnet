using backendnet.Domain.IServices;
using backendnet.Domain.Models;
using backendnet.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using backendnet.DTO;

namespace backendnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuestionarioController : ControllerBase
    {
        private readonly ICuestionarioService _cuestionarioService;
        private readonly IMapper _mapper;
        public CuestionarioController(ICuestionarioService cuestionarioService, IMapper mapper)
        {
            _cuestionarioService = cuestionarioService;
            _mapper = mapper;
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] CuestionarioDTO cuestionarioDTO)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);
                var cuestionario = _mapper.Map<Cuestionario>(cuestionarioDTO);
                cuestionario.UsuarioId = idUsuario;
                cuestionario.FechaCreacion = DateTime.Now;
                cuestionario.Activo = 1;
                await _cuestionarioService.CreateCuestionario(cuestionario);
                return Ok(new { message = "Se agrego el Cuestionario Exitosamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }
        [Route("GetListCuestionarioByUser")]
        [HttpGet]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListCuestionarioByUser()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);
                var listCuestionario = await _cuestionarioService.GetListCuestionarioByUser(idUsuario);
                return Ok(listCuestionario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
