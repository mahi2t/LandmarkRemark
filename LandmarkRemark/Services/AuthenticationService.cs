using LandmarkRemark.Models;
using LandmarkRemark.Repository;

namespace LandmarkRemark.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenService jwtTokenService;
        private readonly ILandmarkService landmarkService;
        private readonly IUserRepository userRepository;


        public AuthenticationService(IJwtTokenService jwtTokenService,
            IUserRepository userRepository,
            ILandmarkService landmarkService)
        {
            this.jwtTokenService = jwtTokenService;
            this.userRepository = userRepository;
            this.landmarkService = landmarkService;
        }

        public LoginResponse AuthenticateUser(LoginRequest loginRequest)
        {
            var loginResponse = new LoginResponse();
            if (!userRepository.IsUserExists(loginRequest.UserName))
            {
                return loginResponse;
            }

            loginResponse.IsUserExists = true;

            if (!userRepository.IsUserCredentialsValid(loginRequest.UserName, loginRequest.Password))
            {
                return loginResponse;
            }

            var user = userRepository.GetUserDetails(loginRequest.UserName);
            var jwtTokenRequest = new JwtTokenRequest
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                JsonWebToken = landmarkService.GetJsonWebTokenSection()
            };

            loginResponse.Token = jwtTokenService.GenerateJwtToken(jwtTokenRequest);

            return loginResponse;
        }
    }
}
