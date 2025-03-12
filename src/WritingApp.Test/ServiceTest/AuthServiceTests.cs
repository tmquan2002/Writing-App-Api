using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WritingApp.Application.ApplicationEntities;
using WritingApp.Application.Dto;
using WritingApp.Application.Interfaces.Repository;
using WritingApp.Application.Services;

namespace WritingApp.Tests.Services
{
    [TestClass]
    public class AuthServiceTests
    {
        private Mock<IAuthRepository> _mockRepository;
        private AuthService _authService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IAuthRepository>();
            _authService = new AuthService(_mockRepository.Object);
        }

        [TestMethod]
        public async Task GetInfo_ReturnsUserDto_WhenUserExists()
        {
            // Arrange
            var userId = "user1";
            var user = new ApplicationUser
            {
                Id = userId,
                Fullname = "John Doe",
                DateOfBirth = new DateOnly(1990, 1, 1),
                Gender = "Male",
                Nationality = "American"
            };
            _mockRepository.Setup(repo => repo.GetInfo(userId)).ReturnsAsync(user);

            // Act
            var result = await _authService.GetInfo(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John Doe", result.Fullname);
        }

        [TestMethod]
        public async Task GetInfo_ReturnsNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = "user1";
            _mockRepository.Setup(repo => repo.GetInfo(userId)).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.GetInfo(userId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task UpdateInfo_ReturnsTrue_WhenUserExists()
        {
            // Arrange
            var userId = "user1";
            var userDto = new UpdateUserDto
            {
                Fullname = "John Doe",
                DateOfBirth = new DateOnly(1990, 1, 1),
                Gender = "Male",
                Nationality = "American"
            };
            var user = new ApplicationUser
            {
                Id = userId,
                Fullname = "Old Name",
                DateOfBirth = new DateOnly(1990, 1, 1),
                Gender = "Male",
                Nationality = "American"
            };
            _mockRepository.Setup(repo => repo.GetInfo(userId)).ReturnsAsync(user);
            _mockRepository.Setup(repo => repo.UpdateInfo(user)).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authService.UpdateInfo(userId, userDto);

            // Assert
            Assert.IsTrue(result);
            _mockRepository.Verify(repo => repo.UpdateInfo(user), Times.Once);
        }

        [TestMethod]
        public async Task UpdateInfo_ReturnsFalse_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = "user1";
            var userDto = new UpdateUserDto
            {
                Fullname = "John Doe",
                DateOfBirth = new DateOnly(1990, 1, 1),
                Gender = "Male",
                Nationality = "American"
            };
            _mockRepository.Setup(repo => repo.GetInfo(userId)).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authService.UpdateInfo(userId, userDto);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
