using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telepresence.API.Services.UserRobot;
using Telepresence.API.Contract.UserRobot;
using System.Net;

namespace Telepresence.API.Controllers
{
    /// <summary>
    /// User Robot Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserRobotController : Controller
    {
        private readonly IUserRobotService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public UserRobotController(IUserRobotService service)
        {
            _service = service;
        }

        /// <summary>
        /// Associate a user as Robot Controller
        /// </summary>
        /// <param name="request">Association information</param>
        /// <returns></returns>
        public async Task<IActionResult> Post([FromBody]AssociateUserRobotRequest request)
        {
            var response = new AssociateUserRobotResponse();

            try
            {
                response = await _service.AssociateAsync(request);

                return Ok(response);
            }
            catch (Exception e)
            {
                response.Exception = e;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
        
        /// <summary>
        /// Sends a commant to a robot
        /// </summary>
        /// <param name="robotId">Robot Id</param>
        /// <param name="request">Command information</param>
        /// <returns></returns>
        [Route("{robotId}")]
        public async Task<IActionResult> SendCommand([FromRoute]string robotId, [FromBody]SendCommandRequest request)
        {
            var response = new SendCommandResponse();

            try
            {
                response = await _service.SendCommandAsync(robotId, request);

                return Ok(response);
            }
            catch (Exception e)
            {
                response.Exception = e;
                response.Success = false;

                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
