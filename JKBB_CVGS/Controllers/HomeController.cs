﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JKBB_CVGS.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.ViewModels.Login user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.Email, user.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                    return View();
                }
            }
            else
            {
                return View();
            }            
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Game(Models.Game game)
        {
            return RedirectToAction("Index", "Game");
        }

        public ActionResult Event(Models.Event eventItem)
        {
            return RedirectToAction("Index", "Event");
        }
    }
}