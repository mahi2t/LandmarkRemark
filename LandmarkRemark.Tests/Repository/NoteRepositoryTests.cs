using LandmarkRemark.Data;
using LandmarkRemark.Models;
using LandmarkRemark.Repository;
using LandmarkRemark.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace LandmarkRemark.Tests.Repository
{
    [TestFixture]
    public class NoteRepositoryTests
    {
        private Mock<ILandmarkService> landmarkService;

        [Test]
        public void AddNote_Should_add_note_on_valid_input()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            landmarkService = new Mock<ILandmarkService>();

            landmarkService.Setup(x => x.IsNoteExistsForThisLocation(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(0);
            using (var context = new ApplicationDbContext(options))
            {
                context.Notes.Add(new Note { Remark = "this is first Note", Latitude = 523.987, Longitude = 908.786, Email = "hi@bye.com" });
                context.Notes.Add(new Note { Remark = "second one", Latitude = 423.987, Longitude = 808.786, Email = "hi@bye.com" });
                context.Notes.Add(new Note { Remark = "this is third Note", Latitude = 323.987, Longitude = 708.786, Email = "hi@bye.com" });
                context.Notes.Add(new Note { Remark = "last Note", Latitude = 223.987, Longitude = 608.786, Email = "hi@bye2.com" });

                context.ApplicationUsers.Add(new ApplicationUser { FirstName = "firstName", LastName = "lastName", Email = "hi@bye.com", Password = "password" });
                context.ApplicationUsers.Add(new ApplicationUser { FirstName = "firstName2", LastName = "lastName2", Email = "hi@bye2.com", Password = "password2" });
                context.SaveChanges();
            }

            var note = new Note
            {
                CreatedDate = DateTime.Now,
                Email = "hi@bye.com",
                Id = 12,
                Latitude = 12,
                Longitude = 23,
                Remark = "test remark"
            };

            using (var context = new ApplicationDbContext(options))
            {
                NoteRepository noteRepository = new NoteRepository(context, landmarkService.Object);

                // Act
                var response = noteRepository.AddNote(note);

                // Assert
                Assert.AreEqual(5, response.Count());
            }
        }


        [Test]
        public void GetAllNotes_Should_return_list_of_notes_available()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            landmarkService = new Mock<ILandmarkService>();

            landmarkService.Setup(x => x.IsNoteExistsForThisLocation(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(0);
            using (var context = new ApplicationDbContext(options))
            {
                context.Notes.Add(new Note { Remark = "this is first Note", Latitude = 523.987, Longitude = 908.786, Email = "hi@bye.com" });
                context.Notes.Add(new Note { Remark = "second one", Latitude = 423.987, Longitude = 808.786, Email = "hi@bye.com" });
                context.ApplicationUsers.Add(new ApplicationUser { FirstName = "firstName", LastName = "lastName", Email = "hi@bye.com", Password = "password" });
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                NoteRepository noteRepository = new NoteRepository(context, landmarkService.Object);

                // Act
                var response = noteRepository.GetAllNotes();

                // Assert
                Assert.AreEqual(2, response.Count());
            }
        }
    }
}
