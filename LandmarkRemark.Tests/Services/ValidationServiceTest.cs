using LandmarkRemark.Models;
using LandmarkRemark.Services;
using NUnit.Framework;

namespace LandmarkRemark.Tests.Services
{
    [TestFixture]
    public class ValidationServiceTest
    {
        private ValidationService validationService;

        [SetUp]
        public void Setup()
        {
            validationService = new ValidationService();
        }

        [TestCase("hi@bye.com", "", true)]
        [TestCase("", "", true)]
        [TestCase(null, "", true)]
        [TestCase("", null, true)]
        [TestCase(null, null, true)]
        [TestCase("hi@bye.com", "password", false)]
        public void IsLoginRequestInvalid_Should_return_true_or_false_based_on_model_state(string email, string password, bool expected)
        {
            // Arrange
            validationService = new ValidationService();
            var request = new LoginRequest()
            {
                UserName = email,
                Password = password
            };

            // Act
            var actual = validationService.IsLoginRequestInvalid(request);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("hi@bye.com", "", "", "", true)]
        [TestCase("", "", "test", "last", true)]
        [TestCase(null, null, null, null, true)]
        [TestCase("", null, null, "", true)]
        [TestCase("", "", "", "", true)]
        [TestCase("hi@bye.com", "password", "first", "last", false)]
        public void IsApplicationUserModelInvalid_Should_return_true_or_false_based_on_model_state(string email, string password, string firstName, string lastName, bool expected)
        {
            // Arrange
            validationService = new ValidationService();
            var request = new ApplicationUser()
            {
                Email = email,
                Password = password,
                LastName=lastName,
                FirstName =firstName
            };

            // Act
            var actual = validationService.IsApplicationUserModelInvalid(request);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
