using LandmarkRemark.Data;
using LandmarkRemark.Models;
using LandmarkRemark.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;

namespace LandmarkRemark.Tests.Services
{
    [TestFixture]
    public class LandmarkServiceTests
    {
        [TestCase("hi@bye.com", 523.987, 908.786, true)]
        [TestCase("hi@bye4.com", 523.987, 808.786, false)]
        [TestCase("hi@bye.com", 523.987, 908.7866, false)]
        public void IsNoteAlreadyExitsForThisLocation_Should_return_zero_or_greater_than_zero_based_on_input(string email, double latitude, double longitude, bool isNoteExists)
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Notes.Add(new Note { Remark = "this is first Note", Latitude = 523.987, Longitude = 908.786, Email = "hi@bye.com" });
                context.Notes.Add(new Note { Remark = "second one", Latitude = 423.987, Longitude = 808.786, Email = "hi@bye.com" });
                context.Notes.Add(new Note { Remark = "this is third Note", Latitude = 323.987, Longitude = 708.786, Email = "hi@bye.com" });
               
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var landmarkService = new LandmarkService(context, configuration.Object);

                // Act
                var response = landmarkService.IsNoteExistsForThisLocation(email, longitude, latitude);

                // Assert
                Assert.IsTrue(isNoteExists ? response > 0 : response == 0);                
            }

        }
    }
}
