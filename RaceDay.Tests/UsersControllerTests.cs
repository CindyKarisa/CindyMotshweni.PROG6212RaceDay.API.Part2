using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Controllers;
using RaceDay.API.Data;
using RaceDay.API.Models;
using Xunit;

namespace RaceDay.Tests
{
    public class UsersControllerTests
    {
        private RaceDayDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<RaceDayDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new RaceDayDbContext(options);
        }

        [Fact]
        public void Register_ShouldReturnOk_WhenUserIsValid()
        {
            // Arrange
            var context = GetDatabaseContext();
            var controller = new UsersController(context);
            var newUser = new RegisterModel
            {
                Username = "testrunner",
                FullName = "Test Runner",
                Email = "runner@test.com",
                Password = "Password123!",
                Role = "Participant"
            };

            // Act
            var result = controller.Register(newUser);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
            Assert.Equal(1, context.Users.Count());
        }

        [Fact]
        public void Login_ShouldReturnUnauthorized_WhenCredentialsAreInvalid()
        {
            // Arrange
            var context = GetDatabaseContext();
            var controller = new UsersController(context);
            var loginModel = new LoginModel
            {
                Email = "nonexistent@test.com",
                Password = "WrongPassword"
            };

            // Act
            var result = controller.Login(loginModel);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}
