namespace LandmarkRemark.Models
{
    public class JwtTokenRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public JsonWebToken JsonWebToken { get; set; }
    }
}
