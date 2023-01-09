using API.Domains;
using API.Interfaces;
using API.Repositories;
using API.ViewModels;
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

        /// <summary>
        /// Gets the frequency of a competitor by its Id
        /// </summary>
        /// <param name="competitorId"></param>
        /// <returns>List of Frequencies</returns>
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

        /// <summary>
        /// Gets the frequency of logged competitor by its JWT Token
        /// </summary>
        /// <returns>List of Frequencies</returns>
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

        /// <summary>
        /// Gets the frequencies of all competitors
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Register a new frequency
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns>Status Code Created</returns>
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

        /// <summary>
        /// Updates 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newFrequency"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Frequency newFrequency)
        {
            try
            {
                Frequency updatedFrequency =  _frequencyRepository.UpdateFrequency(id, newFrequency);
                return Ok(updatedFrequency);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }


        /// <summary>
        /// Checks in a competitor by its Token
        /// </summary>
        /// <param name="check">Data and time of the checkin</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("checkIn")]
        public IActionResult CheckIn(CheckViewModel check)
        {
            try
            {
                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                bool isChecked = _frequencyRepository.CheckInUser(idUser, check);
                if (!isChecked)
                    return NotFound(new {msg = "Frequency already registered" });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

        /// <summary>
        /// Checks out a competitor by its Token
        /// </summary>
        /// <param name="check">Data and time of the checkout</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("checkOut")]
        public IActionResult CheckOut(CheckViewModel check)
        {
            try
            {
                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                bool isChecked = _frequencyRepository.CheckOutUser(idUser, check);
                if (!isChecked)
                    return NotFound(new { msg = "Error while checking out!", solution = "Verify if there is a frequency on this date and if it does not have checkout" }); ;

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
