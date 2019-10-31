using LandmarkRemark.Models;

namespace LandmarkRemark.Services
{
    /// <summary>
    /// Validation Service
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Validate ApplicationUser model
        /// </summary>
        /// <param name="loginRequest">LoginRequest</param>
        /// <returns>bool</returns>
        bool IsLoginRequestInvalid(LoginRequest loginRequest);

        /// <summary>
        /// Validate ApplicationUser model
        /// </summary>
        /// <param name="applicationUser">ApplicationUser</param>
        /// <returns>bool</returns>
        bool IsApplicationUserModelInvalid(ApplicationUser applicationUser);
    }
}
