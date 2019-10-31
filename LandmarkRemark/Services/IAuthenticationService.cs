using LandmarkRemark.Models;

namespace LandmarkRemark.Services
{
    public interface IAuthenticationService
    {
        public LoginResponse AuthenticateUser(LoginRequest loginRequest);
    }
}
