using LandmarkRemark.Models;
using System.Collections.Generic;
using System.Linq;

namespace LandmarkRemark.Repository.Mock
{
    /// <summary>
    /// UserRepository Mock
    /// </summary>
    public class MockUserRepository : IUserRepository
    {
        private readonly List<ApplicationUser> users;

        public MockUserRepository()
        {
            users = new List<ApplicationUser> {
                new ApplicationUser{Email="x.y@z.com", Id=1, FirstName="x", LastName="y" }
            };
        }

        public int AddUser(ApplicationUser user)
        {
            user.Id = users.Max(x => x.Id) + 1;
            users.Add(user);
            return 1;
        }

        public ApplicationUser GetUserDetails(string email)
        {
            return users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public bool IsUserCredentialsValid(string email, string password)
        {
            return users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password) != null;
        }

        public bool IsUserExists(string email)
        {
            var response = GetUserDetails(email);
            return response != null;
        }
    }
}
