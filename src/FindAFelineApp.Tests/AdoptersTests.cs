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

// need to add tests for adopter controller
[TestClass]
    public class AdoptersTests
    {
        private Mock<DbSet<Adopter>> _mockSet;
        private Mock<ApplicationDbContext> _mockContext;
        private CrudRepository<Adopter> _repository;
        private List<Adopter> _data;


        [TestMethod]
        public void TestCreateAdopter_ShouldCreateNewIndividualAdopter()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Adopter>>();
            var mockContext = new Mock<ApplicationDbContext>();
            var mockRepository = new CrudRepository<Adopter>(mockContext.Object);
            var controller = new AdopterController(mockRepository);

            var newAdopter1 = new AdopterDTO
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Email = "john3doe@gmail.com",
                PhoneNumber = "1234567890",
                Address = "123 Main St, City, State, Zip"
                PreferredCatBreed = "Siamese",
                PreferredCatAge = "4",
                PreferredCatPersonality = "Friendly"
            };
            var newAdopter2 = new AdopterDTO
            {
                FirstName = "Jane",
                LastName = "Smith",
                Age = 28,
                Email = "jane_smith@gmail.com",
                PhoneNumber = "0987654321",
                Address = "456 Elm St, City, State, Zip",
                PreferredCatBreed = "Persian",
                PreferredCatAge = "9",
                PreferredCatPersonality = "Playful"
            };
            // Act
            
            CollectiveAssert.DoesNotContain(newAdopter2.Email, "john3doe@gmail.com");
            Assert.IsTrue(newAdopter1.Email != newAdopter2.Email, "Email already exists");
            Assert.AreNotEqual(newAdopter1.PhoneNumber, newAdopter2.PhoneNumber, "Phone number already exists");
            Assert.AreNotEqual(newAdopter1.Address, newAdopter2.Address, "Address already exists");
        }
    }