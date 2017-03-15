using AutoMapper;
using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.Utils;
using CarrerTrack.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarrerTrack.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IAppCommandUserService _userCommandApp;
        private readonly IAppReadUserService _userReadApp;

        public UserController(IAppCommandUserService userCommandApp, IAppReadUserService userReadApp)
        {
            _userCommandApp = userCommandApp;
            _userReadApp = userReadApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegistrationViewModel userRegistrationViewModel)
        {
            var user = Mapper.Map<UserRegistrationViewModel, User>(userRegistrationViewModel);
            
            _userCommandApp.Register(user, userRegistrationViewModel.ConfirmPassword);
            FormsAuthentication.SetAuthCookie(user.Email, false);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<UserLoginViewModel, User>(userLoginViewModel);
                if (_userReadApp.IsLoginSuccessfull(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect");
                }
            }
            return View(userLoginViewModel);
        }
    }
}