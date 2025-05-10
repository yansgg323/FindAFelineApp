using FindAFelineApp.Data;
using FindAFelineApp.Data.Entities;
using FindAFelineApp.Services.Abstractions;
using FindAFelineApp.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using FindAFelineApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using FindAFelineApp.Web.Controllers;
using FindAFelineApp.Services;
using AutoMapper;

// need to add tests for adopter controller
public class AdoptersTests
{
    //private Mock<DbSet<Adopter>> _mockSet;
    //private Mock<ApplicationDbContext> _mockContext;
    //private CrudRepository<Adopter> _repository;
    //private List<Adopter> _data;


    //[Test]
    //public void TestCreateAdopter_ShouldCreateNewIndividualAdopter()
    //{
    //    // Arrange
    //    var mockSet = new Mock<DbSet<Adopter>>();
    //    var mockContext = new Mock<ApplicationDbContext>();
    //    var mockRepository = new CrudRepository<Adopter>(mockContext.Object);
    //var mapper = new Mock<IMapper>();
    //var service = new AdopterService(mockRepository, mapper.Object);
    //    var controller = new AdopterController(service);

    //    var newAdopter1 = new AdopterDTO
    //    {
    //        FirstName = "John",
    //        LastName = "Doe",
    //        Age = 30,
    //        Email = "john3doe@gmail.com",
    //        PhoneNumber = "1234567890",
    //        Address = "123 Main St, City, State, Zip",
    //        PreferredCatBreed = "Siamese",
    //        PreferredCatAge = "4",
    //        PreferredCatPersonality = "Friendly"
    //    };
    //    var newAdopter2 = new AdopterDTO
    //    {
    //        FirstName = "Jane",
    //        LastName = "Smith",
    //        Age = 28,
    //        Email = "jane_smith@gmail.com",
    //        PhoneNumber = "0987654321",
    //        Address = "456 Elm St, City, State, Zip",
    //        PreferredCatBreed = "Persian",
    //        PreferredCatAge = "9",
    //        PreferredCatPersonality = "Playful"
    //    };
    //    // Act

    //    Assert.IsTrue(newAdopter1.Email != newAdopter2.Email, "Email already exists");
    //    Assert.AreNotEqual(newAdopter1.PhoneNumber, newAdopter2.PhoneNumber, "Phone number already exists");
    //    Assert.AreNotEqual(newAdopter1.Address, newAdopter2.Address, "Address already exists");
    //}

    //[Test]
    //public async Task DeleteByIdAsync_Should_Remove_Adopter_If_Exists()
    //{
    //    var adopter = _data.First();
    //    _mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync(adopter);

    //    await _repository.DeleteByIdAsync(1);

    //    _mockSet.Verify(m => m.Remove(adopter), Times.Once);
    //    _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    //}

    //[Test]
    //public async Task GetAllAsync_Should_Return_All_Adopters()
    //{
    //    var result = await _repository.GetAllAsync();

    //    Assert.AreEqual(2, result.Count());
    //}
}



