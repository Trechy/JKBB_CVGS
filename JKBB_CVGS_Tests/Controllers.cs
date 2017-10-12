using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JKBB_CVGS;
using JKBB_CVGS.Controllers;

namespace JKBB_CVGS_Tests
{
    [TestClass]
    public class Controllers
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
            string email = "user@test.com";
            string password = "password";
            //Act
            ViewResult result = hControl.Login() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
