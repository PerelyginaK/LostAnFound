using AutoMapper;
using LostFound.Services.Abstract;
using LostFound.Services.Models;
using LostFound.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LostFound.WebAPI.Controllers
{
    /// <summary>
    /// Employee endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService EmployeeService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public EmployeesController(IEmployeeService EmployeeService, IMapper mapper)
        {
            this.EmployeeService = EmployeeService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Employees by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEmployees([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = EmployeeService.GetEmployees(limit, offset);
            return Ok(mapper.Map<PageResponse<EmployeeResponse>>(pageModel));
        }


        /// <summary>
        /// Delete Employee
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee([FromRoute] Guid id)
        {
            try
            {
                EmployeeService.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Employee
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployee([FromRoute] Guid id)
        {
            try
            {
                var EmployeeModel = EmployeeService.GetEmployee(id);
                return Ok(mapper.Map<EmployeeResponse>(EmployeeModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Add Employee
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeModel Employee)
        {
            var response = EmployeeService.AddEmployee(Employee);
            return Ok(response);
        }
    }
}