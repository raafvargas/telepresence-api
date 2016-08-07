using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telepresence.API.Contract.TelepresenceUser;
using System.Net;
using Telepresence.API.Services.Telepresence;
using Telepresence.API.Contract.User;

namespace Telepresence.API.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly ITelepresenceSerivce _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Dependent service</param>
        public UserController(ITelepresenceSerivce service)
        {
            _service = service;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="request">User information</param>
        /// <returns>Registered user id</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserRegisterRequest request)
        {
            var response = new UserRegisterResponse();

            try
            {
                response = await _service.RegisterAsync(request);

                return Ok(response);
            }
            catch (Exception e)
            {
                response.Exception = e;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        /// <summary>
        /// Gest a user
        /// </summary>
        /// <param name="request">User identifier</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetUserRequest request)
        {
            var response = new GetUserResponse();

            try
            {
                response = await _service.GetAsync(request);

                if (response.User == null)
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
