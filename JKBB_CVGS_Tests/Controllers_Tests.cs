using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public void HomeIndex()
        {
            //Arrange
            HomeController hControl = new HomeController();
            //Act
            ViewResult result = hControl.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Login()
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
            Assert.IsTrue(result.ViewName == "Index");
        }
    }
}
