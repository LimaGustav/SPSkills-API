using API.Domains;
using API.Interfaces;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompetidoresController : ControllerBase
    {
        private ICompetidorRepository _competidorRepository { get; set; }

        public CompetidoresController()
        {
            _competidorRepository = new CompetorRespository();
        }
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

        [Authorize]
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
