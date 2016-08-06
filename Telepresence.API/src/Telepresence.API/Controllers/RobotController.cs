using System;
using System.Threading.Tasks;
using Telepresence.API.Contract.Robot;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Telepresence.API.Services.Robot;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Telepresence.API.Controllers
{
    /// <summary>
    /// Robot Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RobotController : Controller
    {
        private readonly IRobotService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        public RobotController(IRobotService service)
        {
            _service = service;
        }

        /// <summary>
        /// Register a robot
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterRobotRequest robot)
        {
            var response = new RegisterRobotResponse();

            try
            {
                response = await _service.RegisterAsync(robot);

                if (string.IsNullOrWhiteSpace(response.RobotId))
                    return BadRequest();

                return Ok(response);
            }
            catch (Exception e)
            {
                response.Exception = e;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        /// <summary>
        /// Gets a robot
        /// </summary>
        /// <param name="request">Robot information</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetRobotRequest request)
        {
            var response = new GetRobotResponse();

            try
            {
                if (string.IsNullOrWhiteSpace(request.Id))
                    return BadRequest("Must specify the robot Id");

                response = await _service.GetAsync(request);

                if (response.Robot == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception e)
            {
                response.Exception = e;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
