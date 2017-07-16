using AutoMapper;
using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarrerTrack.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly IAppCommandLocationService _locationCommandApp;
        private readonly IAppReadLocationService _locationReadApp;
        private readonly IAppReadUserService _readUserService;

        private readonly User loggedUser;

        public LocationController(IAppCommandLocationService locationCommandApp, IAppReadLocationService locationReadApp,
            IAppReadUserService readUserService)
        {
            _locationCommandApp = locationCommandApp;
            _locationReadApp = locationReadApp;
            _readUserService = readUserService;

            loggedUser = Utils.LoggedUser.GetLoggedUser(_readUserService);
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Location>,IEnumerable<Model.Location>>( _locationReadApp.GetUserLocations(loggedUser.UserId)));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Model.Location location)
        {
            if (ModelState.IsValid)
            {
                var _location = Mapper.Map<Model.Location, Location>(location);
                _location.UserId = loggedUser.UserId;
                _locationCommandApp.Add(_location);

                return RedirectToAction("Index", "Location");
            }
            else
            {
                return View(location);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Location, Model.Location>(_locationReadApp.GetById(id)));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Model.Location location)
        {
            if(ModelState.IsValid)
            {
                var _location = Mapper.Map<Model.Location, Location>(location);
                _location.UserId = loggedUser.UserId;
                _locationCommandApp.Update(_location);
                return RedirectToAction("Index", "Location");
            }
            else
            {
                return View(location);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            var _location = _locationReadApp.GetById(id);
            return View(Mapper.Map<Location, Model.Location>(_location));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Location,Model.Location>(_locationReadApp.GetById(id)));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(Model.Location location)
        {
            _locationCommandApp.Remove(location.Id);
            return RedirectToAction("Index","Location");
        }
    }
}