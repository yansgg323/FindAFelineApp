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
    public class AdopterFosterPArentTests
    {
        private Mock<DbSet<Adopter>> _mockSet;
        private Mock<ApplicationDbContext> _mockContext;
        private CrudRepository<Adopter> _repository;
        private List<Adopter> _data;

        private Mock<DbSet<FosterParent>> _mockSet;
        private Mock<ApplicationDbContext> _mockContext;
        private CrudRepository<FosterParent> _repository;
        private List<FosterParent> _data;


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
                ICollection<Cat> Cats = new List<Cat>()
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
                ICollection<Cat> Cats = new List<Cat>()
            };
            // Act
            
            CollectiveAssert.DoesNotContain(newAdopter2.Email, "john3doe@gmail.com");
            Assert.IsTrue(newAdopter1.Email != newAdopter2.Email, "Email already exists");
            Assert.AreNotEqual(newAdopter1.PhoneNumber, newAdopter2.PhoneNumber, "Phone number already exists");
            Assert.AreNotEqual(newAdopter1.Address, newAdopter2.Address, "Address already exists");
        }

        [Test]
        public void TestCreateFosterParent_ShouldCreateNewIndividualFosterParent()
        {
            // Arrange
            var mockSet = new Mock<DbSet<FosterParent>>();
            var mockContext = new Mock<ApplicationDbContext>();
            var mockRepository = new CrudRepository<FosterParent>(mockContext.Object);
            var controller = new FosterParentController(mockRepository);

            var newFosterParent1 = new FosterParentDTO
            {
                FirstName = "Mary",
                LastName = "Johnson",
                Age = 35,
                Email = "maryJ@gmail.com",
                PhoneNumber = "1234567890",
                Address = "789 Oak St, City, State, Zip"
                ICollection<Cat> Cats = new List<Cat>()
            };
            var newFosterParent2 = new FosterParentDTO
            {
                FirstName = "Tom",
                LastName = "Brown",
                Age = 40,
                Email = "tomBrowny@gmail.com",
                PhoneNumber = "0987654321",
                Address = "321 Pine St, City, State, Zip"
                ICollection<Cat> Cats = new List<Cat>()
            };
            // Act
            CollectiveAssert.DoesNotContain(newFosterParent2.Email, "tomBrowny@gmail.com");
            Assert.IsTrue(newFosterParent1.Email != newFosterParent2.Email, "Email already exists");
            Assert.AreNotEqual(newFosterParent1.PhoneNumber, newFosterParent2.PhoneNumber, "Phone number already exists");
            Assert.AreNotEqual(newFosterParent1.Address, newFosterParent2.Address, "Address already exists");
        }

        [Test]
        public async Task TestICollectionCatsInAdopterORFosterParent_Should_Not_ContainFosterParentORAdopterCats()
        {
            var adopter = new Adopter
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
                ICollection<Cat> Cats = new List<Cat>(
                    {Id = 1,
                     Name = "Whiskers",
                     Age = 2,
                     Breed = "Siamese", 
                     Color = "Brown", 
                     Personality = "Playful",
                     ImageUrl = "https://example.com/whiskers.jpg"
                    }
                    {
                        Id = 2,
                        Name = "Mittens",
                        Age = 3,
                        Breed = "Persian",
                        Color = "White",
                        Personality = "Calm",
                        ImageUrl = "https://example.com/mittens.jpg"
                    }
                )
            };
            var fosterParent = new FosterParent
            {
                FirstName = "Mary",
                LastName = "Johnson",
                Age = 35,
                Email = "maryJ@gmail.com",
                PhoneNumber = "1234567890",
                Address = "789 Oak St, City, State, Zip"
                ICollection<Cat> Cats = new List<Cat>(
                    {Id = 1,
                     Name = "Fluffy",
                     Age = 2,
                     Breed = "Siamese", 
                     Color = "White", 
                     Personality = "Playful",
                     ImageUrl = "https://example.com/fluffy.jpg"
                    }
                    {
                        Id = 2,
                        Name = "Mittens",
                        Age = 3,
                        Breed = "Persian",
                        Color = "Gray",
                        Personality = "Calm",
                        ImageUrl = "https://example.com/mittens.jpg"
                    }
                )
            };

            // Act
            var result = await _repository.GetAllAsync();
            Assert.IsFalse(result.Any(f => f.Cats.Contains(adopter.Cats.FirstOrDefault())));
            Assert.IsFalse(result.Any(a => a.Cats.Contains(fosterParent.Cats.FirstOrDefault())));
        }

        
    }