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
    public class RoleController : Controller
    {
        private readonly IAppReadUserService _readUserService;
        private readonly IAppReadRoleService _readRoleService;
        private readonly IAppCommandRoleService _commandRoleService;

        private readonly User loggedUser;

        public RoleController(IAppReadRoleService roleReadApp, IAppCommandRoleService roleCommandApp,
            IAppReadUserService userReadApp)
        {
            _readRoleService = roleReadApp;
            _commandRoleService = roleCommandApp;
            _readUserService = userReadApp;

            loggedUser = Utils.LoggedUser.GetLoggedUser(_readUserService);
        }

        [Authorize]
        public ActionResult Index()
        {
            var roles = Mapper.Map<IEnumerable<Role>,IEnumerable<Model.Role>>(_readRoleService.GetUserRoles(loggedUser.UserId));
            return View(roles);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var role = Mapper.Map<Domain.Entities.Role, Web.Model.Role>(_readRoleService.GetById(id));
            return View(role);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(Model.Role role)
        {
            _commandRoleService.Remove(role.Id);
            return RedirectToAction("Index","Role");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Model.Role role)
        {
            if (ModelState.IsValid)
            {
                var _role = Mapper.Map<Model.Role, Role>(role);
                _role.UserId = loggedUser.UserId;

                _commandRoleService.Add(_role);
                return RedirectToAction("Index","Role");
            }
            else
            {
                return View(role);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var role = Mapper.Map<Role, Model.Role>(_readRoleService.GetById(id));
            return View(role);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Model.Role role)
        {
            if(ModelState.IsValid)
            {
                var _role = Mapper.Map<Model.Role, Role>(role);
                _role.UserId = loggedUser.UserId;

                _commandRoleService.Update(_role);
                return RedirectToAction("Index","Role");
            }
            else
            {
                return View(role);
            }
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            return View(Mapper.Map<Role, Model.Role>(_readRoleService.GetById(id)));
        }
    }
}