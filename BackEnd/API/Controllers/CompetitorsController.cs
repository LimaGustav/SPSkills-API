using API.Domains;
using API.Interfaces;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private ICompetidorRepository _competidorRepository { get; set; }

        public CompetitorsController()
        {
            _competidorRepository = new CompetorRespository();
        }

        /// <summary>
        /// Gets a Competitor by its userId
        /// </summary>
        /// <param name="userId">Userid of a competitor</param>
        /// <returns>A competitor</returns>
        [Authorize]
        [HttpGet("{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            try
            {
                Competitor competitor = _competidorRepository.GetByUserId(userId);
                if (competitor == null) return NotFound("Competitor Not Found");

                return Ok(competitor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a logged competitor by its JWT Token
        /// </summary>
        /// <returns>A competitor</returns>
        [Authorize]
        [HttpGet("token")]
        public IActionResult GetByToken()
        {
            try
            {
                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                Competitor competitor = _competidorRepository.GetByUserId(idUser);
                if (competitor == null) return NotFound("Competitor Not Found");

                return Ok(competitor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }


        /// <summary>
        /// Gets all Competitors
        /// </summary>
        /// <returns>List of Competitors</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Competitor> competitors = _competidorRepository.GetAll();

                return Ok(competitors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
