using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WritingApp.Application.Dto;
using WritingApp.Application.Interfaces.Repository;
using WritingApp.Application.Services;
using WritingApp.Domain.Entities;

namespace WritingApp.Tests.Services
{
    [TestClass]
    public class WritingServiceTests
    {
        private Mock<IWritingsRepository> _mockRepository;
        private WritingService _writingService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IWritingsRepository>();
            _writingService = new WritingService(_mockRepository.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsAllWritings()
        {
            // Arrange
            var writings = new List<Writing>
            {
                new Writing { Id = 1, Title = "Title1", Type = "Type1", PublishedDate = DateOnly.FromDateTime(DateTime.Now), Description = "Description1", Article = "Article1", Completed = true },
                new Writing { Id = 2, Title = "Title2", Type = "Type2", PublishedDate = DateOnly.FromDateTime(DateTime.Now), Description = "Description2", Article = "Article2", Completed = false }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(writings);

            // Act
            var result = await _writingService.GetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task GetAllCurrentAsync_ReturnsCurrentWritings()
        {
            // Arrange
            var userId = "user1";
            var writings = new List<Writing>
            {
                new Writing { Id = 1, Title = "Title1", Type = "Type1", PublishedDate = DateOnly.FromDateTime(DateTime.Now), Description = "Description1", Article = "Article1", Completed = true },
                new Writing { Id = 2, Title = "Title2", Type = "Type2", PublishedDate = DateOnly.FromDateTime(DateTime.Now), Description = "Description2", Article = "Article2", Completed = false }
            };
            _mockRepository.Setup(repo => repo.GetAllCurrentAsync(userId)).ReturnsAsync(writings);

            // Act
            var result = await _writingService.GetAllCurrentAsync(userId);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsWriting_WhenWritingExists()
        {
            // Arrange
            var writing = new Writing { Id = 1, Title = "Title1", Type = "Type1", PublishedDate = DateOnly.FromDateTime(DateTime.Now), Description = "Description1", Article = "Article1", Completed = true };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(writing);

            // Act
            var result = await _writingService.GetByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Title1", result.Title);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsNull_WhenWritingDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Writing)null);

            // Act
            var result = await _writingService.GetByIdAsync(1);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task CreateAsync_ReturnsNewWritingId()
        {
            // Arrange
            var writingDto = new WritingCreateDto { Title = "Title1", Type = "Type1", PublishedDate = DateOnly.FromDateTime(DateTime.Now), Description = "Description1", Article = "Article1", Completed = true };
            var userId = "user1";
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Writing>())).Callback<Writing>(w => w.Id = 1).Returns(Task.CompletedTask);

            // Act
            var result = await _writingService.CreateAsync(writingDto, userId);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsTrue_WhenWritingExists()
        {
            // Arrange
            var writingDto = new WritingUpdateDto { Title = "UpdatedTitle", Type = "UpdatedType", PublishedDate = DateOnly.FromDateTime(DateTime.Now), Description = "UpdatedDescription", Completed = true };
            var writing = new Writing { Id = 1, Title = "Title1", Type = "Type1", PublishedDate = DateOnly.FromDateTime(DateTime.Now), Description = "Description1", Article = "Article1", Completed = true };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(writing);
            _mockRepository.Setup(repo => repo.UpdateAsync(writing)).Returns(Task.CompletedTask);

            // Act
            var result = await _writingService.UpdateAsync(1, writingDto);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsFalse_WhenWritingDoesNotExist()
        {
            // Arrange
            var writingDto = new WritingUpdateDto { Title = "UpdatedTitle", Type = "UpdatedType", PublishedDate = DateOnly.FromDateTime(DateTime.Now), Description = "UpdatedDescription", Completed = true };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Writing)null);

            // Act
            var result = await _writingService.UpdateAsync(1, writingDto);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsTrue_WhenWritingExists()
        {
            // Arrange
            var writing = new Writing { Id = 1, Title = "Title1", Type = "Type1", PublishedDate = DateOnly.FromDateTime(DateTime.Now), Description = "Description1", Article = "Article1", Completed = true };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(writing);
            _mockRepository.Setup(repo => repo.DeleteAsync(writing)).Returns(Task.CompletedTask);

            // Act
            var result = await _writingService.DeleteAsync(1);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsFalse_WhenWritingDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Writing)null);

            // Act
            var result = await _writingService.DeleteAsync(1);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
