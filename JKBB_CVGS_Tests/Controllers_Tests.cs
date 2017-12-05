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
using JKBB_CVGS.Models;

namespace JKBB_CVGS_Tests
{
    //[TestClass]
    //public class Controllers_Tests
    //{
    //    private CVGS_Context db = new CVGS_Context();
    //    [TestMethod]
    //    public void Can_Got_To_Home_Index()
    //    {
    //        //Arrange
    //        HomeController hControl = new HomeController();
    //        string email = "user@test.com";
    //        //Act
    //        ViewResult result = hControl.Index(email) as ViewResult;
    //        //Assert
    //        Assert.IsNotNull(result);
    //    }
    //    [TestMethod]
    //    public void SignUp()
    //    {

    //        //Arrange
    //        HomeController hControl = new HomeController();
    //        int ID = 10;
    //        string UserName = "hello";
    //        string Email = "new@new.com";
    //        string Password = "password1";
    //        string FirstName = "jason";
    //        string LastName = "guy";
    //        Member member = new Member();
    //        SignUp signUp = new SignUp();
    //        //Act
    //        signUp.MemberID = ID;
    //        signUp.LastName = LastName;
    //        signUp.UserName = UserName;
    //        signUp.Password = Password;
    //        signUp.Email = Email;
    //        signUp.FirstName = FirstName;
    //        member.MemberID = ID;
    //        member.LastName = LastName;
    //        member.UserName = UserName;
    //        member.Password = Password;
    //        member.Email = Email;
    //        member.FirstName = FirstName;
    //        ViewResult result = hControl.SignUp(member, signUp) as ViewResult;
    //        //Assert
    //        Assert.IsNotNull(result);
    //    }
    //    [TestMethod]
    //    public void Can_Login()
    //    {
    //        //Arrange
    //        HomeController hControl = new HomeController();
    //        Login loginUser = new Login();
    //        loginUser.Email = "user@test.com";
    //        loginUser.Password = "password";
    //        //Act 
    //        var result = (RedirectToRouteResult)hControl.Login(loginUser);
    //        //Assert
    //        Assert.AreEqual("Index", result.RouteValues["action"]);
    //        Assert.AreEqual("Home", result.RouteValues["controller"]);
    //    }
    //    [TestMethod]
    //    public void Add_Game()
    //    {
    //        //"GameID,Title,Developer,Publisher,ReleasedDate,BasePrice,Discount"
    //        //Arrange
    //        GameController gControl = new GameController();
    //        int ID = 10;
    //        string Title = "Mario+Rabbids";
    //        string Developer = "Ubisoft";
    //        string Publisher = "Nintendo";
    //        DateTime ReleasedDate = new DateTime(2017, 10, 13); ;
    //        decimal BasePrice = 10;
    //        double Discount = 0.05;
    //        Game game = new Game();
    //        //Act
    //        game.GameID = ID;
    //        game.Title = Title;
    //        game.Developer = Developer;
    //        game.Publisher = Publisher;
    //        game.ReleasedDate = ReleasedDate;
    //        game.BasePrice = BasePrice;
    //        game.Discount = Discount;

    //        db.Games.Add(game);
    //        var result = (RedirectToRouteResult)gControl.Create(game);
    //        //Assert
    //        Assert.IsNotNull(db.Games.Find(game));
    //    }
    //    [TestMethod]
    //    public void Edit_Game()
    //    {

    //    }
    //    [TestMethod]
    //    public void Delete_Game()
    //    {

    //    }
    //    [TestMethod]
    //    public void Add_Event()
    //    {

    //    }
    //    [TestMethod]
    //    public void Edit_Event()
    //    {

    //    }
    //    [TestMethod]
    //    public void Delete_Event()
    //    {

    //    }
    //    [TestMethod]
    //    public void Check_Reports()
    //    {

    //    }
    //[TestMethod]
    //public void Logout()
    //{
    //    //Arrange
    //    HomeController hControl = new HomeController();
    //    Login loginUser = new Login();
    //    loginUser.Email = "user@test.com";
    //    loginUser.Password = "password";

    //    hControl.Login(loginUser);
    //    //Act
    //    var result = hControl.Index(loginUser.Email) as ViewResult;
    //    result = result.LogOut();
    //    //Assert
    //    Assert.AreEqual("SignUp", result.RouteValues["action"]);
    //    Assert.AreEqual("Home", result.RouteValues["controller"]);
    //}
    //}
}
