using AutoMapper;
using LostFound.Services.Abstract;
using LostFound.Services.Models;
using LostFound.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LostFound.WebAPI.Controllers
{
    /// <summary>
    /// User endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public UsersController(IUserService UserService, IMapper mapper)
        {
            this.UserService = UserService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Users by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = UserService.GetUsers(limit, offset);
            return Ok(mapper.Map<PageResponse<UserResponse>>(pageModel));
        }


        /// <summary>
        /// Delete User
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                UserService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get User
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            try
            {
                var UserModel = UserService.GetUser(id);
                return Ok(mapper.Map<UserResponse>(UserModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}