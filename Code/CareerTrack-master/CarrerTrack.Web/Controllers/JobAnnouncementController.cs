using AutoMapper;
using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.Utils;
using CarrerTrack.Web.ViewModel.JobAnnouncement;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarrerTrack.Web.Controllers
{
    public class JobAnnouncementController : Controller
    {

        private readonly IAppCommandJobAnnouncementService _jobAnnouncementCommandApp;
        private readonly IAppReadJobAnnouncementService _jobAnnouncementReadApp;
        private readonly IAppReadSkillService _readSkillService;
        private readonly IAppReadCompanyService _readCompanyService;
        private readonly IAppReadRoleService _readRoleService;
        private readonly IAppReadUserService _readUserService;
        private readonly IAppReadLocationService _readLocationService;

        private readonly User loggedUser;

        public JobAnnouncementController(IAppCommandJobAnnouncementService jobAnnouncementCommandApp, IAppReadLocationService readLocationService,
            IAppReadJobAnnouncementService jobAnnouncementReadApp, IAppReadUserService readUserService, IAppReadSkillService readSkillService, 
            IAppReadRoleService readRoleService, IAppReadCompanyService readCompanyService)
        {
            _jobAnnouncementCommandApp = jobAnnouncementCommandApp;
            _jobAnnouncementReadApp = jobAnnouncementReadApp;
            _readUserService = readUserService;
            _readLocationService = readLocationService;
            _readSkillService = readSkillService;
            _readRoleService = readRoleService;
            _readCompanyService = readCompanyService;

            loggedUser = Utils.LoggedUser.GetLoggedUser(_readUserService);
        }

        // GET: JobAnnouncement
        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.RoleParameter = sortOrder == "Role" ? "RoleDesc" : "Role";
            ViewBag.LocationParameter = sortOrder == "Location" ? "LocationDesc" : "Location";
            ViewBag.CompanyParameter = sortOrder == "Company" ? "CompanyDesc" : "Company";
            ViewBag.DateAddedParameter = sortOrder == "DateAdded" ? "DateAddedDesc" : "DateAdded";

            //pulling the job announcements
            var _jobAnnouncements = _jobAnnouncementReadApp.GetAll();
            var jobAnnouncements = Mapper.Map<IEnumerable< JobAnnouncement>, IEnumerable< Model.JobAnnouncement>>  (_jobAnnouncements);

            switch (sortOrder)
            {
                case "Location":
                    jobAnnouncements = jobAnnouncements.OrderBy(jobAdd => jobAdd.Location.City);
                    break;
                case "LocationDesc":
                    jobAnnouncements = jobAnnouncements.OrderByDescending(jobAdd => jobAdd.Location.City);
                    break;
                case "Company":
                    jobAnnouncements = jobAnnouncements.OrderBy(jobAdd => jobAdd.Company.CompanyName);
                    break;
                case "CompanyDesc":
                    jobAnnouncements = jobAnnouncements.OrderByDescending(jobAdd => jobAdd.Company.CompanyName);
                    break;
                case "Role":
                    jobAnnouncements = jobAnnouncements.OrderBy(jobAdd => jobAdd.Role.Name);
                    break;
                case "RoleDesc":
                    jobAnnouncements = jobAnnouncements.OrderByDescending(jobAdd => jobAdd.Role.Name);
                    break;
                case "DateAdded":
                    jobAnnouncements = jobAnnouncements.OrderBy(jobAdd => jobAdd.DateAdded);
                    break;
                case "DateAddedDesc":
                    jobAnnouncements = jobAnnouncements.OrderByDescending(jobAdd => jobAdd.DateAdded);
                    break;
                default:  
                    break;
            }

            int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NumberOfJobAnnouncementsPerPage"]);
            int pageNumber = (page ?? 1);

            return View(jobAnnouncements.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var job = new AddJobAnnouncement();
            job.Skills = GetSkillsForDropDownControl();
            job.Location = GetLocationsForDropDownControl();
            job.Role = GetRolesForDropDownControl();
            job.Company = GetCompaniesForDropDownControl();

            return View(job);
        }

        /* drop down example from here:
        https://www.asp.net/mvc/overview/older-versions/working-with-the-dropdownlist-box-and-jquery/using-the-dropdownlist-helper-with-aspnet-mvc
        */

        [HttpPost]
        [Authorize]
        public ActionResult Create(AddJobAnnouncement jobAnnouncement)
        {
            if (ModelState.IsValid)
            {
                var _jobAnnouncement = MapAddJobAnnouncementToJobAnnouncement(jobAnnouncement);
                _jobAnnouncement.UserId = loggedUser.UserId;

                _jobAnnouncementCommandApp.AddJobAnnouncement(_jobAnnouncement);
                return RedirectToAction("Index", "JobAnnouncement");
            }
            else
            {
                return View(jobAnnouncement);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var _jobAnnouncement = _jobAnnouncementReadApp.GetById(id);
            var jobAnnouncement = Mapper.Map<JobAnnouncement, Model.JobAnnouncement>(_jobAnnouncement);

            return View(jobAnnouncement);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(Model.JobAnnouncement jobAnnouncement)
        {
            _jobAnnouncementCommandApp.RemoveJobAnnouncemnet(jobAnnouncement.Id);
            return RedirectToAction("Index", "JobAnnouncement");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            var _jobAnnouncement = _jobAnnouncementReadApp.GetById(id);
            var jobAnnouncement = Mapper.Map<JobAnnouncement, Model.JobAnnouncement>(_jobAnnouncement);
            return View(jobAnnouncement);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var _jobAnnouncement = _jobAnnouncementReadApp.GetById(id);
            var jobAnnouncement = MapJobAnnouncementToEditJobAnnouncement(_jobAnnouncement);

            jobAnnouncement.Location = GetLocationsForDropDownControl();
            jobAnnouncement.Role = GetRolesForDropDownControl();
            jobAnnouncement.Company = GetCompaniesForDropDownControl();
            return View(jobAnnouncement);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(EditJobAnnouncement jobAnnouncement)
        {
            if (ModelState.IsValid)
            {
                var _jobAnnouncement = EditJobAnnouncementToJobAnnouncement(jobAnnouncement);
                _jobAnnouncementCommandApp.UpdateJobAnnouncement(_jobAnnouncement);
                return RedirectToAction("Index", "JobAnnouncement");
            }
            else
            {
                return View(jobAnnouncement);
            }
        }

        private SelectList GetLocationsForDropDownControl()
        {
            var locations = Mapper.Map<IEnumerable<Location>, IEnumerable<Model.Location>>
                            (_readLocationService.GetUserLocations(loggedUser.UserId));

            locations = locations.OrderBy(filter => filter.City).ToList();

            return new SelectList(locations, "Id", "City");
        }

        private List<SelectListItem> GetSkillsForDropDownControl()
        {
            List<SelectListItem> ls = new List<SelectListItem>();

            var _skills = _readSkillService.GetAll();
            foreach(var _skill in _skills)
            {
                ls.Add(new SelectListItem { Text = _skill.Name, Value = _skill.Id.ToString() });
            }

            ls.Sort((x, y) => x.Text.CompareTo(y.Text));

            return ls;
        }

        private SelectList GetRolesForDropDownControl()
        {
            var role = Mapper.Map<IEnumerable<Role>, IEnumerable<Model.Role>>
                            (_readRoleService.GetUserRoles(loggedUser.UserId));

            role = role.OrderBy(filter => filter .Name).ToList();

            return new SelectList(role, "Id", "Name");
        }

        private SelectList GetCompaniesForDropDownControl()
        {
            var companies = Mapper.Map<IEnumerable<Company>, IEnumerable<Model.Company>>
                            (_readCompanyService.GetUserCompanies(loggedUser.UserId));

            companies = companies.OrderBy(filter => filter.CompanyName).ToList();

            return new SelectList(companies, "CompanyId", "CompanyName"); ;
        }

        private JobAnnouncement MapAddJobAnnouncementToJobAnnouncement(AddJobAnnouncement jobAnnoucement)
        {
            JobAnnouncement _jobAnnoucement = Mapper.Map<AddJobAnnouncement, JobAnnouncement>(jobAnnoucement);
            _jobAnnoucement.LocationId = jobAnnoucement.LocationId;
            _jobAnnoucement.RoleId = jobAnnoucement.RoleId;
            _jobAnnoucement.CompanyId = jobAnnoucement.CompanyId;
            foreach(var skill in jobAnnoucement.SelectedSkills)
            {
                _jobAnnoucement.Skills.Add(_readSkillService.GetById(skill));
            }

            return _jobAnnoucement;
        }

        private AddJobAnnouncement MapJobAnnouncementToAddJobAnnouncement(JobAnnouncement _jobAnnoucement) 
        {
            AddJobAnnouncement jobAnnoucement = new AddJobAnnouncement();
            jobAnnoucement.Id = _jobAnnoucement.Id;
            jobAnnoucement.CompanyId = _jobAnnoucement.CompanyId;
            jobAnnoucement.Contact = _jobAnnoucement.Contact;
            jobAnnoucement.Content = _jobAnnoucement.Content;
            jobAnnoucement.LocationId = _jobAnnoucement.LocationId;
            jobAnnoucement.Rewards = _jobAnnoucement.Rewards;
            jobAnnoucement.RoleId = _jobAnnoucement.RoleId;
            jobAnnoucement.Source = _jobAnnoucement.Source;
            jobAnnoucement.UserId = _jobAnnoucement.UserId;

            List<Skill> skills = new List<Skill>();
            foreach (var skill in _jobAnnoucement.Skills)
            {
                skills.Add(_readSkillService.GetById(skill.Id));
            }

            return jobAnnoucement;
        }

        private EditJobAnnouncement MapJobAnnouncementToEditJobAnnouncement(JobAnnouncement _jobAnnoucement)
        {
            EditJobAnnouncement editJobAnnoucement = new EditJobAnnouncement();
            editJobAnnoucement.Id = _jobAnnoucement.Id;
            editJobAnnoucement.CompanyId = _jobAnnoucement.CompanyId;
            editJobAnnoucement.Contact = _jobAnnoucement.Contact;
            editJobAnnoucement.Content = _jobAnnoucement.Content;
            editJobAnnoucement.LocationId = _jobAnnoucement.LocationId;
            editJobAnnoucement.Rewards = _jobAnnoucement.Rewards;
            editJobAnnoucement.RoleId = _jobAnnoucement.RoleId;
            editJobAnnoucement.Source = _jobAnnoucement.Source;
            editJobAnnoucement.UserId = _jobAnnoucement.UserId;

            editJobAnnoucement.SelectedSkill = _jobAnnoucement.Skills.Select(x => x.Id);
            editJobAnnoucement.Skills = _readSkillService.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                })
            .ToList();

            return editJobAnnoucement;
        }

        private JobAnnouncement EditJobAnnouncementToJobAnnouncement(EditJobAnnouncement jobAnnouncement)
        {
            JobAnnouncement _jobAnnoucement = Mapper.Map<EditJobAnnouncement,JobAnnouncement>(jobAnnouncement);
            _jobAnnoucement.LocationId = jobAnnouncement.LocationId;
            _jobAnnoucement.RoleId = jobAnnouncement.RoleId;
            _jobAnnoucement.CompanyId = jobAnnouncement.CompanyId;

            _jobAnnoucement.UserId = loggedUser.UserId;
            _jobAnnoucement.Skills = new List<Skill>();
            foreach (var skill in jobAnnouncement.SelectedSkill)
            {
                _jobAnnoucement.Skills.Add(_readSkillService.GetById(skill));
            }

            return _jobAnnoucement;
        }
    }
}
 