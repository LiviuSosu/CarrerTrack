using AutoMapper;
using CarrerTrack.Application.Read.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Web.Model;
using CarrerTrack.Web.Utils;
using CarrerTrack.Domain.Entities;

namespace CarrerTrack.Web.Controllers
{
    public class UserTaskController : Controller
    {
        private readonly IAppReadUserService _readUserService;
        private readonly IAppReadUserTaskService _readUserTaskService;
        private readonly IAppCommandUserTaskService _commandUserTaskService;

        private readonly User loggedUser;

        public UserTaskController(IAppReadUserTaskService userTaskReadApp, IAppCommandUserTaskService userTaskCommandApp,
            IAppReadUserService userReadApp)
        {
            _readUserTaskService = userTaskReadApp;
            _commandUserTaskService = userTaskCommandApp;
            _readUserService = userReadApp;

            loggedUser = Utils.LoggedUser.GetLoggedUser(_readUserService);
            // var user= Session["LoggedUSer"] as User;
        }

        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            #region
            if (loggedUser != null)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParameter = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
                ViewBag.PrioritySortParameter = sortOrder == "Priority" ? "Priority_desc" : "Priority";

                var _userTasksTasks = Mapper.Map<IEnumerable<Domain.Entities.UserTask>, IEnumerable<Model.UserTask>>
                 (_readUserTaskService.GetUserTasks(loggedUser.UserId));

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                if (!String.IsNullOrEmpty(searchString))
                {
                    _userTasksTasks = _userTasksTasks.Where(ut => ut.Name.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "Priority_desc":
                        _userTasksTasks = _userTasksTasks.OrderByDescending(userTask => userTask.Priority);
                        break;
                    case "Priority":
                        _userTasksTasks = _userTasksTasks.OrderBy(userTask => userTask.Priority);
                        break;
                    case "Name":
                        _userTasksTasks = _userTasksTasks.OrderByDescending(userTask => userTask.Name);
                        break;
                    default:  // Name ascending 
                        _userTasksTasks = _userTasksTasks.OrderBy(userTask => userTask.Name).OrderBy(p => p.Priority);
                        break;
                }
                #endregion  
                //some logic on this region block
                int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NumberOfUserTasksPerPage"]); ;
                int pageNumber = (page ?? 1);
                return View(_userTasksTasks.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return null;
            }
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var userTask = Mapper.Map<Domain.Entities.UserTask, Model.UserTask>(_readUserTaskService.GetById(id));
            return View(userTask);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Model.UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                var _userTask = Mapper.Map<Model.UserTask, Domain.Entities.UserTask> (userTask);
                _userTask.UserId = loggedUser.UserId;

                _commandUserTaskService.Add(_userTask);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("","Some fileds were incorrectly filled.");
                return View(userTask);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var _userTask = _readUserTaskService.GetById(id);
            var userTask = Mapper.Map<Domain.Entities.UserTask, Model.UserTask>(_userTask);
            return View(userTask);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(Model.UserTask userTask)
        {
           _commandUserTaskService.Remove(userTask.Id);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var _userTask = _readUserTaskService.GetById(id);
            return View(Mapper.Map<Domain.Entities.UserTask, Model.UserTask>(_userTask));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Model.UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                _commandUserTaskService.Update(Mapper.Map<Model.UserTask, Domain.Entities.UserTask>(userTask));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(userTask);
            }
        }
    }
}