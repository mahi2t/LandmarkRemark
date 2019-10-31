using LandmarkRemark.Models;

namespace LandmarkRemark.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Add new user.
        /// </summary>
        /// <param name="user">Applicationuser</param>
        /// <returns>int</returns>
        int AddUser(ApplicationUser user);

        /// <summary>
        /// Verifies login credentials.
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>bool</returns>
        bool IsUserCredentialsValid(string email, string password);

        /// <summary>
        /// Checks if user already exists in database.
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>bool</returns>email
        bool IsUserExists(string email);

        /// <summary>
        /// Gets user specific details.
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>ApplicationUser</returns>
        ApplicationUser GetUserDetails(string email);
    }
}
