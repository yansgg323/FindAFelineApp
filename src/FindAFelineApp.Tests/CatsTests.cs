using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindAFelineApp.Data;
using FindAFelineApp.Data.Entities;
using FindAFelineApp.Services.Abstractions;
using FindAFelineApp.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using FindAFelineApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;

[TestClass]
    public class CatsTests
    {
        private Mock<DbSet<Cat>> _mockSet;
        private Mock<ApplicationDbContext> _mockContext;
        private CrudRepository<Cat> _repository;
        private List<Cat> _data;

        [SetUp]
        public void Setup()
        {
            _data = new List<Cat>
        {
            new Cat 
            { 
                Id = 1,
                Name = "Whiskers",
                Age = 2,
                Breed = "Siamese",
                Color = "Brown",
                Personality = "Playful"
                ImageUrl = "https://example.com/whiskers.jpg" 
            }
                // },
            new Cat 
            { 
                Id = 2,
                Name = "Mittens",
                Age = 3,
                Breed = "Persian",
                Color = "White",
                Personality = "Calm"
                ImageUrl = "https://example.com/mittens.jpg" 
            }
        };

            var asyncData = _data.AsQueryable().ToAsyncEnumerable();

            _mockSet = new Mock<DbSet<Car>>();

            // This supports .ToListAsync() and other async methods
            _mockSet.As<IAsyncEnumerable<Car>>()
                    .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                    .Returns((CancellationToken _) => asyncData.GetAsyncEnumerator());

            // Support LINQ operations
            _mockSet.As<IQueryable<Car>>().Setup(m => m.Provider).Returns(_data.AsQueryable().Provider);
            _mockSet.As<IQueryable<Car>>().Setup(m => m.Expression).Returns(_data.AsQueryable().Expression);
            _mockSet.As<IQueryable<Car>>().Setup(m => m.ElementType).Returns(_data.AsQueryable().ElementType);
            _mockSet.As<IQueryable<Car>>().Setup(m => m.GetEnumerator()).Returns(_data.GetEnumerator());

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

            _mockContext = new Mock<ApplicationDbContext>(options);
            _mockContext.Setup(c => c.Set<Cat>()).Returns(_mockSet.Object);

            _repository = new CrudRepository<Cat>(_mockContext.Object);
        }


        [TestMethod]
        public void TestCreateCat_ShouldCreateNewIndividualCat()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Cat>>();
            var mockContext = new Mock<ApplicationDbContext>();
            var mockRepository = new CrudRepository<Cat>(mockContext.Object);
            var controller = new CatController(mockRepository);

            var newCat1 = new CatDTO
            {
                Name = "Whiskers",
                Age = 2,
                Breed = "Siamese",
                Color = "Brown",
                Personality = "Playful"
                ImageUrl = "https://example.com/whiskers.jpg"
            };
            var newCat2 = new CatDTO
            {
                Name = "Mittens",
                Age = 3,
                Breed = "Persian",
                Color = "White",
                Personality = "Calm"
                ImageUrl = "https://example.com/mittens.jpg"
            };
            // Act

            CollectionAssert.DoesNotContain(newCat2.Name, "Whiskers");
            Assert.IsTrue(newCat1.Name != newCat2.Name, "Name already exists");
            Assert.AreNotEqual(newCat1.Age, newCat2.Age, "Age already exists");
            Assert.AreNotEqual(newCat1.Breed, newCat2.Breed, "Breed already exists");
            Assert.AreNotEqual(newCat1.Color, newCat2.Color, "Color already exists");
            Assert.AreNotEqual(newCat1.Personality, newCat2.Personality, "Personality already exists");
            Assert.AreNotEqual(newCat1.ImageUrl, newCat2.ImageUrl, "Image URL already exists");
            Assert.AreNotEqual(newCat1.Id, newCat2.Id, "ID already exists");

        }

        [Test]
        public async Task DeleteByIdAsync_Should_Remove_Cat_If_Exists()
        {
            var cat = _data.First();
            _mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync(cat);

            await _repository.DeleteByIdAsync(1);

            _mockSet.Verify(m => m.Remove(cat), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task GetAllAsync_Should_Return_All_Cats()
        {
            var result = await _repository.GetAllAsync();

            Assert.AreEqual(2, result.Count());
        }
    }

    