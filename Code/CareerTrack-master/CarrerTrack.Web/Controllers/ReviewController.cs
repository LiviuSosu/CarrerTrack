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
    public class ReviewController : Controller
    {
        private readonly User loggedUser;
        private readonly IAppCommandReviewService _reviewCommandApp;
        private readonly IAppReadReviewService _reviewReadApp;
        private readonly IAppReadUserService _readUserService;

        public ReviewController(IAppCommandReviewService reviewCommandApp, IAppReadReviewService reviewReadApp
            ,IAppReadUserService readUserService)
        {
            _reviewCommandApp = reviewCommandApp;
            _reviewReadApp = reviewReadApp;
            _readUserService = readUserService;

            loggedUser = Utils.LoggedUser.GetLoggedUser(_readUserService);
        }
        // GET: Review

        /*
        I used this totorial for learning to work with modals: 
        http://www.c-sharpcorner.com/UploadFile/092589/implementing-modal-pop-up-in-mvc-application/
        */
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var reviews = Mapper.Map<IEnumerable< Review > ,IEnumerable <Model.Review>>(_reviewReadApp.GetCompanyReviews(SelectedCompany.SelectedCompanyId));

            int pageSize = 7;
            int pageNumber = 1;
            return PartialView(reviews.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Model.Review review)
        {
            var _review = Mapper.Map<Model.Review, Review>(review);
            _review.CompanyId = SelectedCompany.SelectedCompanyId;
            _review.UserId = loggedUser.UserId;

            _reviewCommandApp.Add(_review);
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }

        [HttpGet]
        [Authorize]
        public ActionResult Cancel()
        {
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}