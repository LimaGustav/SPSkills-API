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
    public class FrequenciesController : ControllerBase
    {
        private IFrequencyRepository _frequencyRepository { get; set; }

        public FrequenciesController()
        {
            _frequencyRepository = new FrequencyRepository();
        }
        [Authorize]
        [HttpGet("{competitorId}")]
        public IActionResult GetByCompetitorId(int competitorId)
        {
            try
            {
                List<Frequency> frequencies = _frequencyRepository.GetByCompetitorId(competitorId);
                return Ok(frequencies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

        [Authorize]
        [HttpGet("token")]
        public IActionResult GetByToken()
        {
            try
            {
                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                List<Frequency> frequencies = _frequencyRepository.GetByUserId(idUser);
                return Ok(frequencies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Frequency> frequencies = _frequencyRepository.GetAll();
                return Ok(frequencies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Frequency frequency)
        {
            try
            {
                bool added = _frequencyRepository.RegisterFrequency(frequency);
                if (added)
                    return StatusCode(201);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
