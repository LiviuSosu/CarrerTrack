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
    public class InterviewQuestionController : Controller
    {
        private readonly IAppCommandInterviewQuestionService _interviewQuestionCommandApp;
        private readonly IAppReadInterviewQuestionService _interviewQuestionReadApp;
        private readonly IAppReadUserService _readUserService;
        private readonly IAppReadCompanyService _readCompanyService;

        private readonly User loggedUser;

        public InterviewQuestionController(IAppReadUserService readUserService, IAppReadInterviewQuestionService interviewQuestionReadApp,
            IAppCommandInterviewQuestionService interviewQuestionCommandApp, IAppReadCompanyService readCompanyService)
        {
            _readUserService = readUserService;
            _interviewQuestionReadApp = interviewQuestionReadApp;
            _interviewQuestionCommandApp = interviewQuestionCommandApp;
            _readCompanyService = readCompanyService;

            loggedUser = Utils.LoggedUser.GetLoggedUser(_readUserService);
        }

        // GET: InterviewQuestion
        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var _interviewQuestions = _interviewQuestionReadApp.GetAll();
            var interviewQuestions = new List<Model.InterviewQuestion>();

            var companiesList = _readCompanyService.GetUserCompanies(loggedUser.UserId);
            foreach (var _interviewQuestion in _interviewQuestions)
            {
                interviewQuestions.Add(new Model.InterviewQuestion()
                {
                    AnswerContent = _interviewQuestion.AnswerContent,
                    CompanyName = companiesList.FirstOrDefault(l => l.CompanyId == _interviewQuestion.CompanyId).CompanyName,
                    Id = _interviewQuestion.Id,
                    QuestionContent = _interviewQuestion.QuestionContent
                });
            }

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
                interviewQuestions = interviewQuestions.Where(a => a.QuestionContent.Contains(searchString)).ToList();
            }

            int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NumberOfInterviewQuestionsPerPage"]);
            int pageNumber = (page ?? 1);
            return View(interviewQuestions.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var job = new Model.InterviewQuestion();
            GetCompaniesForDropDownControl();
            job.Company = GetCompaniesForDropDownControl();
            return View(job);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Model.InterviewQuestion interviewQuestion, string Company)
        {
            ModelState["Company"].Errors.Clear();
            if (ModelState.IsValid)
            {
                var _interviewQuestion = new InterviewQuestion();
                _interviewQuestion.AnswerContent = interviewQuestion.AnswerContent;
                _interviewQuestion.CompanyId = Convert.ToInt32(Company);
                _interviewQuestion.QuestionContent = interviewQuestion.QuestionContent;

                _interviewQuestionCommandApp.Add(_interviewQuestion);

                return RedirectToAction("Index", "InterviewQuestion");
            }
            else
            {
                return View(interviewQuestion);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var _interviewQuestion = _interviewQuestionReadApp.GetById(id);

            var interviewQuestion = new Model.InterviewQuestion();
            interviewQuestion.AnswerContent = _interviewQuestion.AnswerContent;

            var companiesList = _readCompanyService.GetUserCompanies(loggedUser.UserId);
            interviewQuestion.CompanyName = companiesList.FirstOrDefault(l => l.CompanyId == _interviewQuestion.CompanyId).CompanyName;
            interviewQuestion.Id = _interviewQuestion.Id;
            interviewQuestion.QuestionContent = _interviewQuestion.QuestionContent;

            interviewQuestion.Company = GetCompaniesForDropDownControl();

            return View(interviewQuestion);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Model.InterviewQuestion interviewQuestion, string Company)
        {
            ModelState["Company"].Errors.Clear();
            if (ModelState.IsValid)
            {
                var _interviewQuestion = new InterviewQuestion();
                _interviewQuestion.AnswerContent = interviewQuestion.AnswerContent;
                _interviewQuestion.Id = interviewQuestion.Id;
                _interviewQuestion.QuestionContent = interviewQuestion.QuestionContent;
                _interviewQuestion.CompanyId = Convert.ToInt32(Company);

                _interviewQuestionCommandApp.Update(_interviewQuestion);

                return RedirectToAction("Index", "InterviewQuestion");
            }
            else
            {
                return View(interviewQuestion);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            var _interviewQuestion = _interviewQuestionReadApp.GetById(id);

            var interviewQuestion = new Model.InterviewQuestion();
            interviewQuestion.AnswerContent = _interviewQuestion.AnswerContent;

            var companiesList = _readCompanyService.GetUserCompanies(loggedUser.UserId);
            interviewQuestion.CompanyName = companiesList.FirstOrDefault(l => l.CompanyId == _interviewQuestion.CompanyId).CompanyName;
            interviewQuestion.Id = _interviewQuestion.Id;
            interviewQuestion.QuestionContent = _interviewQuestion.QuestionContent;

            return View(interviewQuestion);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var _interviewQuestion = _interviewQuestionReadApp.GetById(id);

            var interviewQuestion = new Model.InterviewQuestion();
            interviewQuestion.AnswerContent = _interviewQuestion.AnswerContent;

            var companiesList = _readCompanyService.GetUserCompanies(loggedUser.UserId);
            interviewQuestion.CompanyName = companiesList.FirstOrDefault(l => l.CompanyId == _interviewQuestion.CompanyId).CompanyName;
            interviewQuestion.Id = _interviewQuestion.Id;
            interviewQuestion.QuestionContent = _interviewQuestion.QuestionContent;

            return View(interviewQuestion);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(Model.InterviewQuestion interviewQuestion)
        {
            _interviewQuestionCommandApp.Remove(interviewQuestion.Id);
            return RedirectToAction("Index", "InterviewQuestion");
        }

        private List<SelectListItem> GetCompaniesForDropDownControl()
        {
            List<SelectListItem> companies = new List<SelectListItem>();
            var lm = _readCompanyService.GetUserCompanies(loggedUser.UserId).ToList();
            foreach (var temp in lm)
            {
                companies.Add(new SelectListItem() { Text = temp.CompanyName, Value = temp.CompanyId.ToString() });
            }
            return companies;
        }
    }
}