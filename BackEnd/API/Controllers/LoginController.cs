using API.Domains;
using API.Interfaces;
using API.Repositories;
using API.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;


        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository(new Contexts.SpEntities());
        }

        /// <summary>
        /// Authenticate a user in the Application
        /// </summary>
        /// <param name="login"></param>
        /// <returns>A JWT Token</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                User user = _usuarioRepository.Login(login.Email, login.Password);

                if (user == null)
                {
                    return Unauthorized(new { msg = "Invalid Email or Password" });
                }


                var myClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.IdUserType.ToString()),

                    // armazena na Claim personalizada role o tipo de usuário que está logado
                    new Claim("role", user.IdUserType.ToString()),

                    // Armazena na Claim o nome do usuário que foi autenticado
                   // new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("XbY9ZHvgpgHJbXYjL6ndSfERgq0Gp0O7d2gzNgUEWqOyEIW5xY"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var myToken = new JwtSecurityToken(
                        issuer: "SPSkills.webAPI",
                        audience: "SPSkills.webAPI",
                        claims: myClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(myToken)
                });
            }


            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Authenticate a user in the Mobile Application
        /// </summary>
        /// <param name="login"></param>
        /// <returns>A JWT Token</returns>
        [HttpPost("Mobile")]
        public IActionResult LoginMobile(LoginViewModel login)
        {
            try
            {
                User user = _usuarioRepository.Login(login.Email, login.Password);

                if (user == null)
                {
                    return Unauthorized(new { msg = "Invalid Email or Password" });
                }

                if (user.IdUserType != 3)
                {
                    return StatusCode(403);
                }

                var myClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.IdUserType.ToString()),

                    // armazena na Claim personalizada role o tipo de usuário que está logado
                    new Claim("role", user.IdUserType.ToString()),

                    // Armazena na Claim o nome do usuário que foi autenticado
                   // new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("XbY9ZHvgpgHJbXYjL6ndSfERgq0Gp0O7d2gzNgUEWqOyEIW5xY"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var myToken = new JwtSecurityToken(
                        issuer: "SPSkills.webAPI",
                        audience: "SPSkills.webAPI",
                        claims: myClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(myToken)
                });
            }


            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
