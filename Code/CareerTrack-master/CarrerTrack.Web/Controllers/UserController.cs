using AutoMapper;
using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.Utils;
using CarrerTrack.Web.ViewModel;
using System.Web.Mvc;
using System.Web.Security;

namespace CarrerTrack.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IAppCommandUserService _userCommandApp;
        private readonly IAppReadUserService _userReadApp;

        private readonly User loggedUser;

        public UserController(IAppCommandUserService userCommandApp, IAppReadUserService userReadApp)
        {
            _userCommandApp = userCommandApp;
            _userReadApp = userReadApp;

            loggedUser = LoggedUser.GetLoggedUser(_userReadApp);
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
                var user = Mapper.Map<User>(userLoginViewModel);
                if (_userReadApp.IsLoginSuccessfull(user))
                {
                    //if(user.IsActive==false)
                    //{
                    //    _userCommandApp.ActivateAccount(user);
                    //}
                    FormsAuthentication.SetAuthCookie(user.Email, false);

                 //   var user2 = _userReadApp.GetUserByEmail(user.Email);
                 //   Session["LoggedUSer"] = user2.UserId;

                    return RedirectToAction("Index", "Home", user.UserId);
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect");
                }
            }
            return View(userLoginViewModel);
        }

        [HttpGet]
        public ActionResult Account()
        {    
            Model.User user = Mapper.Map<Domain.Entities.User, Model.User>(loggedUser);
            return View(user);
        }

        [HttpPost]
        [HttpParamAction]
        public ActionResult UpdateAccount(Model.User user)
        {
            ModelState["OldPassword"].Errors.Clear();
            ModelState["NewPassword"].Errors.Clear();
            ModelState["ConfirmPassword"].Errors.Clear();

            if (ModelState.IsValid)
            {
                var _user = _userReadApp.GetById(user.UserId);
                _user.FirstName = user.FirstName;
                _user.MiddleName = user.MiddleName;
                _user.LastName = user.LastName;
                _user.Email = user.Email;

                _userCommandApp.Update(_user);
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        [HttpParamAction]
        public ActionResult ChangePassword(Model.User user)
        {    
            ModelState["FirstName"].Errors.Clear();
            ModelState["LastName"].Errors.Clear();
            ModelState["Email"].Errors.Clear();

            if (ModelState.IsValid)
            {
                var _user = _userReadApp.GetById(loggedUser.UserId);
                _userCommandApp.ChangePassword(_user, user.OldPassword,user.NewPassword,user.ConfirmPassword);

                return Redirect(Request.UrlReferrer.PathAndQuery);
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet]
        public ActionResult Deactivate(int id)
        {
            var _user = _userReadApp.GetById(id);
            _userCommandApp.DeactivateAccount(_user);

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ActivateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActivateAccount(FormCollection form)
        {
            string userEmail = form["Email"];
            string password = form["Password"];
            var _user = _userReadApp.GetUserByEmail(userEmail);
            _user.Password = password;
            if (_userReadApp.IsLoginSuccessfullForAccountActivation(_user))
            {
                _userCommandApp.ActivateAccount(_user);
                return RedirectToAction("Home", "Index");
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect");
                return View(form);
            }
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(FormCollection form)
        {
            string userEmail = form["Email"];
            
            var _user = _userReadApp.GetUserByEmail(userEmail);
            _userCommandApp.ForgotPassword(_user);

            return RedirectToAction ("MailSent","User");
        }

        [HttpGet]
        public ActionResult MailSent()
        {
            return View();
        }
    }
}