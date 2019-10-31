using LandmarkRemark.Models;
using LandmarkRemark.Services;
using LandmarkRemark.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LandmarkRemark.Controllers
{
    [Route(Constants.ApiRoutes.BASE)]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IValidationService validationService;

        public AuthenticationController(IAuthenticationService authenticationService,
            IValidationService validationService)
        {
            this.authenticationService = authenticationService;
            this.validationService = validationService;
        }
        /// <summary>
        /// Post method to verify the user
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <returns>IActionResult</returns>
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            if (validationService.IsLoginRequestInvalid(loginRequest))
            {
                return BadRequest();
            }

            var response = authenticationService.AuthenticateUser(loginRequest);
            return Ok(response);
        }
    }
}