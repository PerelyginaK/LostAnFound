using AutoMapper;
using LostFound.Services.Abstract;
using LostFound.Services.Models;
using LostFound.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LostFound.WebAPI.Controllers
{
    /// <summary>
    /// Bureau endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BureausController : ControllerBase
    {
        private readonly IBureauService BureauService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public BureausController(IBureauService BureauService, IMapper mapper)
        {
            this.BureauService = BureauService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Bureaus by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBureaus([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = BureauService.GetBureaus(limit, offset);
            return Ok(mapper.Map<PageResponse<BureauResponse>>(pageModel));
        }



        /// <summary>
        /// Delete Bureau
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBureau([FromRoute] Guid id)
        {
            try
            {
                BureauService.DeleteBureau(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Bureau
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBureau([FromRoute] Guid id)
        {
            try
            {
                var BureauModel = BureauService.GetBureau(id);
                return Ok(mapper.Map<BureauResponse>(BureauModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Add Bureau
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBureau([FromBody] BureauModel Bureau)
        {
            var response = BureauService.AddBureau(Bureau);
            return Ok(response);
        }
    }
}