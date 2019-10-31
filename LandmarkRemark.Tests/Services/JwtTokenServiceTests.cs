using LandmarkRemark.Models;
using LandmarkRemark.Services;
using NUnit.Framework;

namespace LandmarkRemark.Tests.Services
{
    [TestFixture]
    public class JwtTokenServiceTests
    {
        private JwtTokenService jwtTokenSerivce;

        [Test]
        public void GenerateJwtToken_Should_generate_and_return_token()
        {
            // Arrange          
            jwtTokenSerivce = new JwtTokenService();

            var request = new JwtTokenRequest()
            {
                Email = "hi@bye.com",
                FirstName = "first",
                LastName = "last",
                JsonWebToken = new JsonWebToken
                {
                    Domain = "",
                    SecretKey = "thisIsSecrectKeyValue"
                }
            };

            // Act
            var response = jwtTokenSerivce.GenerateJwtToken(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Length > 50);
        }
    }
}
