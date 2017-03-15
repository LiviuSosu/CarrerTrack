using AutoMapper;
using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.Utils;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace CarrerTrack.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IAppCommandBookService _bookCommandApp;
        private readonly IAppReadBookService _bookReadApp;
        private readonly IAppReadUserService _readUserService;

        private readonly User loggedUser;

        public BookController(IAppCommandBookService articleCommandApp, IAppReadBookService readBookApp,
            IAppReadUserService readUserService)
        {
            _bookCommandApp = articleCommandApp;
            _readUserService = readUserService;
            _bookReadApp = readBookApp;

            loggedUser = Utils.LoggedUser.GetLoggedUser(_readUserService);
        }

        // GET: Book
        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParameter = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.StatusParameter = sortOrder == "Status" ? "Status_desc" : "Status";

            var _articles = Mapper.Map<IEnumerable<Book>, IEnumerable<Model.Book>>
                (_bookReadApp.GetUserBooks(loggedUser.UserId));

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
                _articles = _articles.Where(a => a.BookTitle.Contains(searchString) || a.Description.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Status":
                    _articles = _articles.OrderByDescending(article => article.Status);
                    break;
                case "Status_desc":
                    _articles = _articles.OrderBy(article => article.Status);
                    break;
                case "title_desc":
                    _articles = _articles.OrderByDescending(article => article.BookTitle);
                    break;
                default:  // Name ascending 
                    _articles = _articles.OrderBy(article => article.BookTitle);
                    break;
            }

            int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NumberOfArticlesPerPage"]);
            int pageNumber = (page ?? 1);
            return View(_articles.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Model.Book book)
        {
            if(ModelState.IsValid)
            {
                var _book = Mapper.Map<Model.Book, Book>(book);

                if (book.File != null)
                {
                    _book.ContentType = book.File.ContentType;
                    using (var reader = new System.IO.BinaryReader(book.File.InputStream))
                    {
                        _book.Content = reader.ReadBytes(book.File.ContentLength);
                    }
                }

                _book.UserId = loggedUser.UserId;
                _bookCommandApp.Add(_book);

                return RedirectToAction("Index", "Book");
            }
            else
            {
                return View(book);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            var _book = _bookReadApp.GetById(id);
            Model.Book book = Mapper.Map<Book, Model.Book>(_book);
            if(_book.Content!=null)
            {
                ViewBag.LinkAvailable = true;
            }
            else
            {
                ViewBag.LinkAvailable = false;
            }

            return View(book);
        }

        [HttpGet]
        [Authorize]
        public FileResult DownloadBook(int id)
        {
            var _book = _bookReadApp.GetById(id);

            byte[] fileBytes = _book.Content;
            string fileName = _book.BookTitle + ".pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var _book = _bookReadApp.GetById(id);
            if(_book.Content != null)
            {
                ViewBag.LinkAvailable = true;
            }
            else
            {
                ViewBag.LinkAvailable = false;
            }
            Model.Book book = Mapper.Map<Book, Model.Book>(_book);
            return View(book);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Model.Book book)
        {
            if(ModelState.IsValid)
            {
                var _book = Mapper.Map<Model.Book, Book>(book);

                if (book.File != null)
                {
                    _book.ContentType = book.File.ContentType;
                    using (var reader = new System.IO.BinaryReader(book.File.InputStream))
                    {
                        _book.Content = reader.ReadBytes(book.File.ContentLength);
                    }
                }

                _book.UserId = loggedUser.UserId;
                _bookCommandApp.Update(_book);

                return RedirectToAction("Index","Book");
            }
            else
            {
                return View(book);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult DeleteBook(int id)
        {
            _bookCommandApp.RemoveBookAttachement(id);
            return RedirectToAction("Index","Book");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var _book = _bookReadApp.GetById(id);
            var book = Mapper.Map<Book, Model.Book > (_book);

            return View(book);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(Model.Book book)
        {
            _bookCommandApp.Remove(book.Id);
            return RedirectToAction("Index","Book");
        }
    }
}