using LandmarkRemark.Models;

namespace LandmarkRemark.Services
{
    public interface IJwtTokenService
    {
        public string GenerateJwtToken(JwtTokenRequest jwtTokenRequest);
    }
}
