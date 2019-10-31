using LandmarkRemark.Models;
using LandmarkRemark.Repository;
using LandmarkRemark.Services;
using LandmarkRemark.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LandmarkRemark.Controllers
{
    /// <summary>
    /// Users Api Controller
    /// </summary>
    [ApiController]
    [Route(Constants.ApiRoutes.BASE)]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IValidationService validationService;

        public UserController(IUserRepository userRepository,
            IValidationService validationService)
        {
            this.userRepository = userRepository;
            this.validationService = validationService;
        }

        /// <summary>
        /// Post method to save the user
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <returns>IActionResult</returns>
        [HttpPost("register")]
        public IActionResult AddUser(ApplicationUser user)
        {
            if (validationService.IsApplicationUserModelInvalid(user))
            {
                return BadRequest();
            }

            var response = userRepository.AddUser(user);
            return Ok(response);
        }
    }
}