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

// need to add tests for FosterParent controller
[TestClass]
    public class FosterParentsTests
    {
        private Mock<DbSet<FosterParent>> _mockSet;
        private Mock<ApplicationDbContext> _mockContext;
        private CrudRepository<FosterParent> _repository;
        private List<FosterParent> _data;


        [TestMethod]
        public void TestCreateFosterParent_ShouldCreateNewIndividualFosterParent()
        {
            // Arrange
            var mockSet = new Mock<DbSet<FosterParent>>();
            var mockContext = new Mock<ApplicationDbContext>();
            var mockRepository = new CrudRepository<FosterParent>(mockContext.Object);
            var controller = new FosterParentController(mockRepository);

            var newFosterParent1 = new FosterParentDTO
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Email = "john3doe@gmail.com",
                PhoneNumber = "1234567890",
                Address = "123 Main St, City, State, Zip",
                ICollection<Cat> Cats = new List<Cat>()
            };
            var newFosterParent2 = new FosterParentDTO
            {
                FirstName = "Jane",
                LastName = "Smith",
                Age = 28,
                Email = "jane_smith@gmail.com",
                PhoneNumber = "0987654321",
                Address = "456 Elm St, City, State, Zip"
                IColection<Cat> Cats = new List<Cat>()
            };
            // Act
            
            CollectiveAssert.DoesNotContain(newFosterParent2.Email, "john3doe@gmail.com");
            Assert.IsTrue(newFosterParent1.Email != newFosterParent2.Email, "Email already exists");
            Assert.AreNotEqual(newFosterParent1.PhoneNumber, newFosterParent2.PhoneNumber, "Phone number already exists");
            Assert.AreNotEqual(newFosterParent1.Address, newFosterParent2.Address, "Address already exists");
        }

        [Test]
        public async Task DeleteByIdAsync_Should_Remove_FosterParent_If_Exists()
        {
            var FosterParent = _data.First();
            _mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync(FosterParent);

            await _repository.DeleteByIdAsync(1);

            _mockSet.Verify(m => m.Remove(FosterParent), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task GetAllAsync_Should_Return_All_FosterParents()
        {
            var result = await _repository.GetAllAsync();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetByIdAsync_Should_Return_FosterParent_If_Exists()
        {
            var FosterParent = _data.First();
            _mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync(FosterParent);

            var result = await _repository.GetByIdAsync(1);

            Assert.AreEqual(FosterParent, result);
        }

        [Test]
        public async Task GetByIdAsync_Should_Return_Null_If_FosterParent_Does_Not_Exist()
        {
            var result = await _repository.GetByIdAsync(999);

            Assert.IsNull(result);
        }
    }