using API.Domains;
using API.Interfaces;
using API.Repositories;
using API.ViewModels;
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

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                User usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return Unauthorized(new { msg = "E-mail ou senha inválidos" });
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdUserType.ToString()),

                    // armazena na Claim personalizada role o tipo de usuário que está logado
                    new Claim("role", usuarioBuscado.IdUserType.ToString()),

                    // Armazena na Claim o nome do usuário que foi autenticado
                   // new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("XbY9ZHvgpgHJbXYjL6ndSfERgq0Gp0O7d2gzNgUEWqOyEIW5xY"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "SPSkills.webAPI",
                        audience: "SPSkills.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }


            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
