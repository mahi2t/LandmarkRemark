using LandmarkRemark.Data;
using LandmarkRemark.Models;
using LandmarkRemark.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace LandmarkRemark.Tests.Repository
{
    [TestFixture]
    public class UserRepositoryTests
    {
        [TestCase("hi@bye.com", 0)]
        [TestCase("hi@bye4.com", 1)]
        public void AddUser_Should_add_user_to_database_if_not_exists_else_no(string email, int expected)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.ApplicationUsers.Add(new ApplicationUser { FirstName = "firstName", LastName = "lastName", Email = "hi@bye.com", Password = "password" });
                context.ApplicationUsers.Add(new ApplicationUser { FirstName = "firstName2", LastName = "lastName2", Email = "hi@bye2.com", Password = "password2" });
                context.SaveChanges();
            }

            var user = new ApplicationUser
            {
                FirstName = "something",
                LastName = "nothing",
                Email = email
            };

            using (var context = new ApplicationDbContext(options))
            {
                var userRepository = new UserRepository(context);

                // Act
                var response = userRepository.AddUser(user);

                // Assert
                Assert.AreEqual(expected, response);
            }
        }

        [TestCase("hi@bye.com","password", true)]
        [TestCase("hi@by5.com", "", false)]
        [TestCase("hi@bye.com", "psword", false)]
        [TestCase("", "", false)]
        [TestCase(null, null, false)]
        public void IsUserCredentialsValid_Should_return_true_or_false_if_exists_else_null(string email, string password, bool exists)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.ApplicationUsers.Add(new ApplicationUser { FirstName = "firstName", LastName = "lastName", Email = "hi@bye.com", Password = "password" });
                context.SaveChanges();
            }

            var user = new ApplicationUser
            {
                FirstName = "something",
                LastName = "nothing",
                Password = "password",
                Email = email
            };

            using (var context = new ApplicationDbContext(options))
            {
                var userRepository = new UserRepository(context);

                // Act
                var response = userRepository.IsUserCredentialsValid(user.Email, user.Password);

                // Assert
               
            }
        }

        [TestCase("hi@bye.com", true)]
        [TestCase("hi@bye5.com", false)]
        public void GetUserDetails_Should_return_true_or_false_if_exists_else_null(string email, bool exists)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.ApplicationUsers.Add(new ApplicationUser { FirstName = "firstName", LastName = "lastName", Email = "hi@bye.com", Password = "password" });
                context.SaveChanges();
            }

            var user = new ApplicationUser
            {
                FirstName = "something",
                LastName = "nothing",
                Password = "password",
                Email = email
            };

            using (var context = new ApplicationDbContext(options))
            {
                var userRepository = new UserRepository(context);

                // Act
                var response = userRepository.GetUserDetails(user.Email);

                // Assert
                if (exists)
                {
                    Assert.IsNotNull(response);
                }
                else { Assert.IsNull(response); }
            }
        }

    }
}
