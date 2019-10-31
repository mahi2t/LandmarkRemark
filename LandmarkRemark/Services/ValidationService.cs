using LandmarkRemark.Models;

namespace LandmarkRemark.Services
{
    /// <summary>
    /// Validation Service
    /// </summary>
    public class ValidationService : IValidationService
    {
        /// <summary>
        /// Validates ApplicationUser model.
        /// </summary>
        /// <param name="applicationUser">ApplicationUser</param>
        /// <returns>bool</returns>
        public bool IsApplicationUserModelInvalid(ApplicationUser applicationUser)
        {
            return applicationUser == null ||
                string.IsNullOrWhiteSpace(applicationUser.Email) ||
                string.IsNullOrWhiteSpace(applicationUser.Password) ||
                string.IsNullOrWhiteSpace(applicationUser.FirstName) ||
                 string.IsNullOrWhiteSpace(applicationUser.LastName);
        }

        /// <summary>
        /// Validates LoginRequest model.
        /// </summary>
        /// <param name="loginRequest">LoginRequest</param>
        /// <returns>bool</returns>
        public bool IsLoginRequestInvalid(LoginRequest loginRequest)
        {
            return loginRequest == null ||
               string.IsNullOrWhiteSpace(loginRequest.UserName) ||
                string.IsNullOrWhiteSpace(loginRequest.Password);
        }
    }
}
