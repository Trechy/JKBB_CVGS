using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JKBB_CVGS;
using JKBB_CVGS.Controllers;
using JKBB_CVGS.Models.ViewModels;

namespace JKBB_CVGS_Tests
{
    [TestClass]
    public class Controllers_Tests
    {
        [TestMethod]
        public void Can_Got_To_Home_Index()
        {
            //Arrange
            HomeController hControl = new HomeController();
            string email = "user@test.com";
            //Act
            ViewResult result = hControl.Index(email) as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void SignUp()
        {

        }
        [TestMethod]
        public void Can_Login()
        {
            //Arrange
            HomeController hControl = new HomeController();
            Login loginUser = new Login();
            loginUser.Email = "user@test.com";
            loginUser.Password = "password";
            //Act 
            ViewResult result = hControl.Login(loginUser) as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Add_Game()
        {

        }
        [TestMethod]
        public void Edit_Game()
        {

        }
        [TestMethod]
        public void Delete_Game()
        {

        }
        [TestMethod]
        public void Add_Event()
        {

        }
        [TestMethod]
        public void Edit_Event()
        {

        }
        [TestMethod]
        public void Delete_Event()
        {

        }
        [TestMethod]
        public void Check_Reports()
        {

        }
        [TestMethod]
        public void Logout()
        {
            //Arrange
            HomeController hControl = new HomeController();
            Login loginUser = new Login();
            loginUser.Email = "user@test.com";
            loginUser.Password = "password";

            hControl.Login(loginUser);
            //Act
            var result = hControl.Index(loginUser.Email) as ViewResult;
            result = result.LogOut();
            //Assert
            Assert.AreEqual("SignUp", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }
    }
}
