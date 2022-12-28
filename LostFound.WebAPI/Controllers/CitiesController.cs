using AutoMapper;
using LostFound.Services.Abstract;
using LostFound.Services.Models;
using LostFound.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LostFound.WebAPI.Controllers
{
    /// <summary>
    /// City endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CitysController : ControllerBase
    {
        private readonly ICityService CityService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public CitysController(ICityService CityService, IMapper mapper)
        {
            this.CityService = CityService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Citys by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCitys([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = CityService.GetCitys(limit, offset);
            return Ok(mapper.Map<PageResponse<CityResponse>>(pageModel));
        }

        /// <summary>
        /// Delete City
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCity([FromRoute] Guid id)
        {
            try
            {
                CityService.DeleteCity(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get City
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCity([FromRoute] Guid id)
        {
            try
            {
                var CityModel = CityService.GetCity(id);
                return Ok(mapper.Map<CityResponse>(CityModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Add City
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCity([FromBody] CityModel City)
        {
            var response = CityService.AddCity(City);
            return Ok(response);
        }
    }
}