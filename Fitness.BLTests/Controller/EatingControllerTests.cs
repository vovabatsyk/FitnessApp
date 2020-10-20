using System;
using System.Linq;
using Fitness.BL.Controller;
using Fitness.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fitness.BLTests.Controller
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 100), rnd.Next(50, 100), rnd.Next(50, 100), rnd.Next(50, 100));

            // Act
            eatingController.Add(food, 100);

            // Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.Last().Key.Name);
        }
    }
}