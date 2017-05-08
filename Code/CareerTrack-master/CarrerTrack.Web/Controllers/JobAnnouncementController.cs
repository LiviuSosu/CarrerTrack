using AutoMapper;
//using CareerTrack.Logging;
using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.ViewModel.JobAnnouncement;
using PagedList;
using System;
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
        //ILogging log;

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
            //log = new Logging();
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
            var jobAnnouncements = Mapper.Map<IEnumerable<JobAnnouncement>, IEnumerable<Model.JobAnnouncement>>(_jobAnnouncements);

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
            var jobAdd = new AddJobAnnouncementViewModel();
            ViewBag.JobAnnouncementRequiredSkills = GetAllJobAddSkills(null);
            ViewBag.Locations = GetLocationsForDropDownControl();
            ViewBag.Roles = GetRolesForDropDownControl();

            //companies are fetched on GetCompanies() due the fact that we are using a autocomplete box.
            return View();
        }

        /* drop down example from here:
        https://www.asp.net/mvc/overview/older-versions/working-with-the-dropdownlist-box-and-jquery/using-the-dropdownlist-helper-with-aspnet-mvc
        */

        [HttpPost]
        [Authorize]
        public ActionResult Create(AddJobAnnouncementViewModel jobAnnouncement, FormCollection form)
        {
            //IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            AddJobAnnouncementViewModel addJobAnnouncement = GetAddJobAnnouncementViewModel(form);

            var _jobAnnouncement = MapAddJobAnnouncementViewModelToJobAnnouncement(addJobAnnouncement);
            _jobAnnouncementCommandApp.Add(_jobAnnouncement);

            return RedirectToAction("Index", "JobAnnouncement");
        }

        private AddJobAnnouncementViewModel GetAddJobAnnouncementViewModel(FormCollection form)
        {
            AddJobAnnouncementViewModel addJobAnnouncement = new AddJobAnnouncementViewModel();

            addJobAnnouncement.Content = form["Content"];
            addJobAnnouncement.Rewards = form["Rewards"];
            string lobAnnouncementRequiredSkills = form["JobAnnouncementRequiredSkills"];
            string[] skillIDs = lobAnnouncementRequiredSkills.Split(',');
            List<Model.Skill> skills = new List<Model.Skill>();
            foreach (var skillID in skillIDs)
            {
                var skill = _readSkillService.GetById(Convert.ToInt32(skillID));
                skills.Add(new Model.Skill { Id = skill.Id, Name = skill.Name });
            }
            addJobAnnouncement.JobAnnouncementRequiredSkills = skills;

            string sLocationID = form["Location"];
            addJobAnnouncement.LocationId = Convert.ToInt32(sLocationID);

            addJobAnnouncement.Source = form["Source"];
            addJobAnnouncement.Contact = form["Contact"];
            addJobAnnouncement.RoleId = Convert.ToInt32(form["Role"]);
            string companyName = form["CompanyName"];
            addJobAnnouncement.CompanyId = _readCompanyService.GetUserCompanies(loggedUser.UserId).Where(c => c.CompanyName == companyName).First().CompanyId;
            addJobAnnouncement.UserId = loggedUser.UserId;

            return addJobAnnouncement;
        }

        private JobAnnouncement MapAddJobAnnouncementViewModelToJobAnnouncement(AddJobAnnouncementViewModel addJobAnnouncement)
        {
            JobAnnouncement jobAnnouncement = new JobAnnouncement();

            jobAnnouncement.CompanyId = addJobAnnouncement.CompanyId;
            jobAnnouncement.Contact = addJobAnnouncement.Contact;
            jobAnnouncement.Content = addJobAnnouncement.Content;

            jobAnnouncement.LocationId = addJobAnnouncement.LocationId;

            jobAnnouncement.Rewards = addJobAnnouncement.Rewards;
            jobAnnouncement.RoleId = addJobAnnouncement.RoleId;
            jobAnnouncement.Source = addJobAnnouncement.Source;
            jobAnnouncement.UserId = addJobAnnouncement.UserId;

            List<Skill> _skills = new List<Skill>();
            jobAnnouncement.Skills = new List<Skill>();
            foreach (var skill in addJobAnnouncement.JobAnnouncementRequiredSkills)
            {
                jobAnnouncement.Skills.Add(new Skill { Id = skill.Id, Name = skill.Name });
            }

            return jobAnnouncement;
        }

        private MultiSelectList GetAllJobAddSkills(string[] selectedValues)
        {
            var _skills = _readSkillService.GetAll();
            return new MultiSelectList(_skills, "Id", "Name", selectedValues);
        }

        private MultiSelectList GetJobAddSkillsForEdit(string[] selectedValues, JobAnnouncement jobAnnouncement)
        {
            return new MultiSelectList(jobAnnouncement.Skills, "Id", "Name", selectedValues);
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
            EditJobAnnouncementViewModel jobAnnouncement = MapEditJobAnnouncemnetToEditJobAnnouncementViewModel(_jobAnnouncement);
            string[] myStr = new string[2];
            myStr[0] = "1";
            myStr[1] = "4";

            ViewBag.JobAnnouncementRequiredSkills = GetAllJobAddSkills(jobAnnouncement.skillsSelectedValues);

            //jobAnnouncement.Location = GetLocationsForDropDownControl();
            //jobAnnouncement.Role = GetRolesForDropDownControl();
            //jobAnnouncement.CompanyName = _jobAnnouncement.Company.CompanyName;
            return View(jobAnnouncement);
        }

        private EditJobAnnouncementViewModel MapEditJobAnnouncemnetToEditJobAnnouncementViewModel(JobAnnouncement _jobAnnouncement)
        {
            var jobAnnouncement = new EditJobAnnouncementViewModel();

            jobAnnouncement.Contact = _jobAnnouncement.Contact;
            jobAnnouncement.Content = _jobAnnouncement.Content;
            jobAnnouncement.Id = _jobAnnouncement.Id;
            jobAnnouncement.Rewards = _jobAnnouncement.Rewards;
            jobAnnouncement.Source = _jobAnnouncement.Source;

            int skillsArrayLenght = _jobAnnouncement.Skills.Count;
            string[] skills = new string[skillsArrayLenght];
            int index = 0;
            foreach (var skill in _jobAnnouncement.Skills)
            {
                skills[index] = skill.Id.ToString();
                index++;
            }
            jobAnnouncement.skillsSelectedValues = skills;

            return jobAnnouncement;
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(FormCollection form)
        {

            return RedirectToAction("Index", "JobAnnouncement");
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

        public JsonResult GetCompanies(string Companies, string term = "")
        {
            //autocomplete http://stackoverflow.com/questions/37585676/autocomplete-dropdown-in-mvc5
            var companies = Mapper.Map<IEnumerable<Company>, IEnumerable<Model.Company>>
                          (_readCompanyService.GetUserCompanies(loggedUser.UserId));

            var objCustomerlist = companies.Where(c => c.CompanyName.ToUpper()
                            .Contains(term.ToUpper()))
                            .Select(c => new { Name = c.CompanyName, ID = c.CompanyId })
                            .Distinct().ToList();
            return Json(objCustomerlist, JsonRequestBehavior.AllowGet);
        }
    }
}
 