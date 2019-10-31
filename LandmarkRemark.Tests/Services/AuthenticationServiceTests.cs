using LandmarkRemark.Models;
using LandmarkRemark.Repository;
using LandmarkRemark.Services;
using Moq;
using NUnit.Framework;

namespace LandmarkRemark.Tests.Services
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IJwtTokenService> jwtTokenService;
        private Mock<ILandmarkService> landmarkService;
        private Mock<IUserRepository> userRepository;
        private AuthenticationService authenticationService;

        [SetUp]
        public void Setup()
        {
            jwtTokenService = new Mock<IJwtTokenService>();
            landmarkService = new Mock<ILandmarkService>();
            userRepository = new Mock<IUserRepository>();
            authenticationService = new AuthenticationService(jwtTokenService.Object, userRepository.Object, landmarkService.Object);
        }

        [TestCase("hi@bye.com", "sda", false, true)]
        [TestCase("test@test.com", "test", false, false)]
        [TestCase("his@bye.com", "password", true, true)]
        public void AuthenticateUser_Should_verify_if_user_exists_then_valid_credentials_and_generate_token_if_valid(string email, string password, bool isCredentialsValid, bool isUserExists)
        {
            // Arrange
            userRepository.Setup(x => x.IsUserExists(email)).Returns(isUserExists);
            userRepository.Setup(x => x.IsUserCredentialsValid(email, password)).Returns(isCredentialsValid);
            userRepository.Setup(x => x.GetUserDetails(email)).Returns(new ApplicationUser() { Email = email, Password = password, FirstName = "test", LastName = "last" });
            jwtTokenService.Setup(x => x.GenerateJwtToken(It.IsAny<JwtTokenRequest>())).Returns("token");

            var request = new LoginRequest() { Password = password, UserName = email };

            // Act
            var actual = authenticationService.AuthenticateUser(request);

            // Assert

            Assert.IsNotNull(actual);
            userRepository.Verify(x => x.IsUserExists(It.IsAny<string>()), Times.Once);

            if (isUserExists)
            {
                userRepository.Verify(x => x.IsUserCredentialsValid(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
                Assert.IsTrue(actual.IsUserExists);
            }
            else
            {
                userRepository.Verify(x => x.IsUserCredentialsValid(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
                jwtTokenService.Verify(x => x.GenerateJwtToken(It.IsAny<JwtTokenRequest>()), Times.Never);
                Assert.IsFalse(actual.IsUserExists);
            }

            if (isCredentialsValid)
            {
                userRepository.Verify(x => x.GetUserDetails(It.IsAny<string>()), Times.Once);
                jwtTokenService.Verify(x => x.GenerateJwtToken(It.IsAny<JwtTokenRequest>()), Times.Once);
                Assert.AreEqual("token", actual.Token);
            }
            else
            {
                userRepository.Verify(x => x.GetUserDetails(It.IsAny<string>()), Times.Never);
                jwtTokenService.Verify(x => x.GenerateJwtToken(It.IsAny<JwtTokenRequest>()), Times.Never);
                Assert.IsNull(actual.Token);
            }
        }
    }
}
