using AutoMapper;
using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Web.Utils;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarrerTrack.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppReadUserService _userReadApp;
        private readonly IAppReadUserTaskService _readUserTaskApp;

        public HomeController(IAppReadUserTaskService userTaskRead, IAppReadUserService userReadApp)
        {
            _userReadApp = userReadApp;
            _readUserTaskApp = userTaskRead;
        }

        public ActionResult Index()
        {
            ViewBag.userLogged = Utils.LoggedUser.GetLoggedUser(_userReadApp);

            var _userTasksTasks = Mapper.Map<IEnumerable<Domain.Entities.UserTask>, IEnumerable<Model.UserTask>>
              (_readUserTaskApp.GetUserTasks(6));
            ViewBag.UserTasks = _userTasksTasks;
            return View();
        }
    }
}