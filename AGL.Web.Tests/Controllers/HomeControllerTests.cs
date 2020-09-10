using Xunit;
using AGL.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using AGL.Web.Repository;
using AGL.Web.Models;
using AGL.Web.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AGL.Web.Controllers.Tests
{
    public class HomeControllerTests
    {
        [Fact()]
        public async Task IndexTest()
        {
            //Arrange
            var persons = new List<Person>() {
               new Person(){  Name = "Bob", Gender = "Male", Age = 23, Pets = new List<Pet>() { new Pet() { Name = "Garfield", Type = "Cat" } } },
               new Person(){  Name = "Jennifer", Gender = "Female", Age = 18, Pets = new List<Pet>() { new Pet() { Name = "Garfield", Type = "Cat" } } },
               new Person(){  Name = "Fred", Gender = "Male", Age = 40, Pets = new List<Pet>() { new Pet() { Name = "Tom", Type = "Cat" }, new Pet() { Name = "Max", Type = "Cat" }, new Pet() { Name = "Jim", Type = "Cat" } } },
               new Person(){  Name = "Samantha", Gender = "Female", Age = 40, Pets = new List<Pet>() { new Pet() { Name = "Tabby", Type = "Cat" } } },
               new Person(){  Name = "Alice", Gender = "Female", Age = 64, Pets = new List<Pet>() { new Pet() { Name = "Simba", Type = "Cat" } } }
            };

            var aglRepository = new Mock<IAGLRepository>();
            aglRepository.Setup(svc => svc.GetPeronsWithCatsAsync())
                 .ReturnsAsync(persons);
            var homeControllerTest = new HomeController(aglRepository.Object);

            // Act
            var result = await homeControllerTest.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);                        
            Assert.IsType<List<HomeViewModel>>(viewResult.ViewData.Model);
        }
    }
}