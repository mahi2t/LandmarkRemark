using LandmarkRemark.Data;
using LandmarkRemark.Models;
using System.Linq;

namespace LandmarkRemark.Repository
{
    /// <summary>
    /// User repository performs user related database operations.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Method to add user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>int</returns>
        public int AddUser(ApplicationUser user)
        {
            var emailExists = dbContext.ApplicationUsers.FirstOrDefault(x => x.Email == user.Email) != null;
            if (emailExists)
            {
                return 0;
            }
            dbContext.Add(user);
            var response = dbContext.SaveChanges();
            return response;
        }

        /// <summary>
        /// Checks if user already exists in database.
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>bool</returns>email
        public bool IsUserExists(string email)
        {
            var response = GetUserDetails(email);
            return response != null;
        }

        /// <summary>
        /// Verifies login credentials.
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>bool</returns>
        public bool IsUserCredentialsValid(string email, string password)
        {
            var response = dbContext.ApplicationUsers.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
            return response != null;
        }

        /// <summary>
        /// Gets user specific details.
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>ApplicationUser</returns>
        public ApplicationUser GetUserDetails(string email)
        {
            var response = dbContext.ApplicationUsers.FirstOrDefault(x => x.Email.Equals(email));
            return response;
        }
    }
}
