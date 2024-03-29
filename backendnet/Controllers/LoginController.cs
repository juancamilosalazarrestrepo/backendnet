﻿using backendnet.Domain.IServices;
using backendnet.Domain.Models;
using backendnet.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace backendnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public readonly IConfiguration _config;
        
        public LoginController(ILoginService loginService, IConfiguration config)
        {
         
            _config = config;
            _loginService = loginService;
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                var user = await _loginService.ValidateUser(usuario);
                if (user == null)
                {
                    return BadRequest(new { message = "Usuario o Contraseña invalidos" });
                }

                var variable = _config["variable:vari"];
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
                string tokenString = JwtConfigurator.GetToken(user,_config);
                return Ok(new { token = tokenString });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
