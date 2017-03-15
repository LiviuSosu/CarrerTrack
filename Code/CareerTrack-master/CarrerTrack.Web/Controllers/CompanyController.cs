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
    public class CompanyController : Controller
    {
        private readonly IAppCommandCompanyService _companyCommandApp;
        private readonly IAppReadCompanyService _companyReadApp;
        private readonly IAppReadReviewService _reviewReadApp;
        private readonly IAppReadUserService _readUserService;

        private readonly User loggedUser;

        public CompanyController(IAppCommandCompanyService companyCommandApp, IAppReadCompanyService companyArtilceApp,
            IAppReadReviewService reviewReadApp, IAppReadUserService readUserService)
        {
            _companyCommandApp = companyCommandApp;
            _companyReadApp = companyArtilceApp;
            _reviewReadApp = reviewReadApp;
            _readUserService = readUserService;

            loggedUser = Utils.LoggedUser.GetLoggedUser(_readUserService);
        }

        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString)
        {
            if (_reviewReadApp.GetAll().Count()>0)
            {
                ViewBag.CompanyHasReviews = true;
            }
            else
            {
                ViewBag.CompanyHasReviews = false;
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParameter = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SizeSortParameter = sortOrder == "Size" ? "SizeDesc" : "Size";

            var companies = Mapper.Map<IEnumerable<Company>, IEnumerable<Model.Company>>
                (_companyReadApp.GetUserCompanies(loggedUser.UserId));

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                companies = companies.Where(a => a.CompanyName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "SizeDesc":
                    companies = companies.OrderByDescending(company => company.Size);
                    break;
                case "Size":
                    companies = companies.OrderBy(company => company.Size);
                    break;
                case "name_desc":
                    companies = companies.OrderByDescending(company => company.CompanyName);
                    break;
                default:  // Name ascending 
                    companies = companies.OrderBy(company => company.CompanyName);
                    break;
            }
            return View(companies);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Model.Company company)
        {
            if(ModelState.IsValid)
            {
                var _company = Mapper.Map<Model.Company, Company>(company);
                _company.UserId = loggedUser.UserId;
                _companyCommandApp.Add(_company);

                return RedirectToAction("Index","Company");
            }
            else
            {
                return View(company);
            }
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            SelectedCompany.SelectedCompanyId = id;
            var _company = _companyReadApp.GetById(id);
            return View(Mapper.Map<Company,Model.Company>(_company));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var _company = _companyReadApp.GetById(id);
            return View(Mapper.Map<Company, Model.Company>(_company));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Model.Company company)
        {
            if(ModelState.IsValid)
            {
                var _company = Mapper.Map<Model.Company,Company>(company);
                _company.UserId = loggedUser.UserId;
                _companyCommandApp.Update(_company);

                return RedirectToAction("Index","Company");
            }
            else
            {
                return View(company);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Company,Model.Company>(_companyReadApp.GetById(id)));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(Model.Company company)
        {
            _companyCommandApp.Remove(Mapper.Map<Model.Company, Company>(company).CompanyId);
            return RedirectToAction("Index","Company");
        }
    }
}