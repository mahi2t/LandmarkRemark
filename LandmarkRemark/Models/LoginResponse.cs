namespace LandmarkRemark.Models
{
    /// <summary>
    /// Login Response Model
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Is user exists.
        /// </summary>
        public bool IsUserExists { get; set; }

        /// <summary>
        /// Jwt token
        /// </summary>
        public string Token { get; set; }
    }
}
