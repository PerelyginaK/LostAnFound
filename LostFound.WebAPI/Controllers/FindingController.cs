using AutoMapper;
using LostFound.Services.Abstract;
using LostFound.Services.Models;
using LostFound.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LostFound.WebAPI.Controllers
{
    /// <summary>
    /// Finding endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FindingsController : ControllerBase
    {
        private readonly IFindingService FindingService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public FindingsController(IFindingService FindingService, IMapper mapper)
        {
            this.FindingService = FindingService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Findings by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetFindings([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = FindingService.GetFindings(limit, offset);
            return Ok(mapper.Map<PageResponse<FindingResponse>>(pageModel));
        }

        /// <summary>
        /// Update Finding
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFinding([FromRoute] Guid id, [FromBody] UpdateFindingRequest model)
        {
            try
            {
                var resultModel = FindingService.UpdateFinding(id, mapper.Map<UpdateFindingModel>(model));

                return Ok(mapper.Map<FindingResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Finding
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteFinding([FromRoute] Guid id)
        {
            try
            {
                FindingService.DeleteFinding(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Finding
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFinding([FromRoute] Guid id)
        {
            try
            {
                var FindingModel = FindingService.GetFinding(id);
                return Ok(mapper.Map<FindingResponse>(FindingModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Add Finding
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddFinding([FromBody] FindingModel Finding)
        {
            var response = FindingService.AddFinding(Finding);
            return Ok(response);
        }
    }
}