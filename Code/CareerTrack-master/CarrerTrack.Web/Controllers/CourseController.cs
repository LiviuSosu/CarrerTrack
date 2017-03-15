using AutoMapper;
using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.Utils;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarrerTrack.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly IAppCommandCourseService _courseCommandApp;
        private readonly IAppReadCourseService _courseReadApp;
        private readonly IAppReadUserService _readUserService;

        private readonly User loggedUser;

        public CourseController(IAppCommandCourseService courseCommandApp, IAppReadCourseService readCourseApp,
            IAppReadUserService readUserService)
        {
            _courseCommandApp = courseCommandApp;
            _courseReadApp = readCourseApp;
            _readUserService = readUserService;

            loggedUser = Utils.LoggedUser.GetLoggedUser(_readUserService);
        }

        // GET: Course
        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParameter = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var courses = Mapper.Map<IEnumerable<Course>, IEnumerable<Model.Course>>
               (_courseReadApp.GetUserCourse(loggedUser.UserId));

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
                courses = courses.Where(a => a.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    courses = courses.OrderByDescending(course => course.Name);
                    break;
                default:  // Name ascending 
                    courses = courses.OrderBy(course => course.Name);
                    break;
            }

            int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NumberOfCoursesPerPage"]);
            int pageNumber = (page ?? 1);
            return View(courses.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            return View(Mapper.Map<Course,Model.Course>(_courseReadApp.GetById(id)));
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Course, Model.Course>(_courseReadApp.GetById(id)));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Model.Course course)
        {
            if(ModelState.IsValid)
            {
                var _course = Mapper.Map<Model.Course, Course>(course);
                _course.UserId = loggedUser.UserId;
                _courseCommandApp.Update(_course);

                return RedirectToAction("Index","Course");
            }
            else
            {
                return View(course);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Model.Course course)
        {
            if (ModelState.IsValid)
            {
                var _course = Mapper.Map<Model.Course, Course>(course);
                _course.UserId = loggedUser.UserId;
                _courseCommandApp.Add(_course);

                return RedirectToAction("Index","Course");
            }
            else
            {
                return View(course);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var _course = _courseReadApp.GetById(id);
            _course.UserId = loggedUser.UserId;

            return View(Mapper.Map<Course,Model.Course>(_course));        
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(Model.Course course)
        {
            _courseCommandApp.Remove(course.Id);

            return RedirectToAction("Index","Course");
        }
    }
}