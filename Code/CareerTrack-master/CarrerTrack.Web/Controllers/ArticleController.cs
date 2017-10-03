using AutoMapper;
//using CareerTrack.Logging;
//using CareerTrack.Utils.Functionalities.SimilarStrings;
using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarrerTrack.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IAppCommandArticleService _articleCommandApp;
        private readonly IAppReadArticleService _articleReadApp;
        private readonly IAppReadUserService _readUserService;

        private readonly User loggedUser;
       // private ILogging logger;
       // private ISimlarStrings similarStrings;

        public ArticleController(IAppCommandArticleService articleCommandApp, IAppReadArticleService readArtilceApp,
            IAppReadUserService readUserService)
        {
            _articleCommandApp = articleCommandApp;
            _articleReadApp = readArtilceApp;
            _readUserService = readUserService;

            loggedUser = Utils.LoggedUser.GetLoggedUser(_readUserService);
           // logger = new Logging();
           // similarStrings = new SimilarStrings();
        }

        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? readFilter, int? page=1)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParameter = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.IsReadParameter = sortOrder == "Read" ? "IsNotRead" : "Read";

            var _articles = Mapper.Map<IEnumerable<Domain.Entities.Article>, IEnumerable<Model.Article>>
                (_articleReadApp.GetUserArticles(loggedUser.UserId));

            if (readFilter == 1)
            {
                _articles = _articles.Where(a => a.IsRead == true);
            }
            if (readFilter == 2)
            {
                _articles = _articles.Where(a => a.IsRead == false);
            }

            ViewBag.allArticles = _articles.Count();

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
                _articles = _articles.Where(a => a.Title.ToLower().Contains(searchString.ToLower()));
            }


            switch (sortOrder)
            {
                case "Read":
                    _articles = _articles.OrderByDescending(article => article.IsRead);
                    break;
                case "IsNotRead":
                    _articles = _articles.OrderBy(article=>article.IsRead);
                    break; 
                case "title_desc":
                    _articles = _articles.OrderByDescending(article => article.Title);
                    break;
                default:  // Name ascending 
                    _articles = _articles.OrderBy(article => article.Title);
                    break;
            }

            int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NumberOfArticlesPerPage"]);
            int pageNumber = (page ?? 1);
            ViewBag.CurrentPage = page;
            return View(_articles.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create(int page)
        {
            ViewBag.CurrentPage = page;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model.Article article, int page)
        {
            article.UserId = loggedUser.UserId;

            var _article = Mapper.Map<Model.Article,Domain.Entities.Article>(article);
            _articleCommandApp.Add(_article);

            return RedirectToAction("Index", "Article", new { page = page });
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id, int page)
        {
            ViewBag.CurrentPage = page;
            var article = _articleReadApp.GetById(id);
            var _article = Mapper.Map<Domain.Entities.Article, Model.Article>(article);
            return View(_article);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id, int page)
        {
            ViewBag.CurrentPage = page;

            var _article = _articleReadApp.GetById(id);
            return View(Mapper.Map<Domain.Entities.Article, Model.Article>(_article));
        }

        [HttpPost]
        public ActionResult Delete(Model.Article article, int page)
        {
            var _article = _articleReadApp.GetById(article.ArticleId);
            _articleCommandApp.Remove(_article.ArticleId);
            return RedirectToAction("Index","Article", new { page = page });
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id, int page)
        {
            ViewBag.CurrentPage = page;

            return View(Mapper.Map<Domain.Entities.Article, Model.Article>(_articleReadApp.GetById(id)));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Model.Article article, int page)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CurrentPage = page;

                var _article = Mapper.Map<Model.Article, Domain.Entities.Article>(article);
                _article.UserId = loggedUser.UserId;
                _articleCommandApp.Update(_article);
                return RedirectToAction("Index", "Article", new { page = page });
            }
            else
            {
                return View(article);
            }
        }
    }
}