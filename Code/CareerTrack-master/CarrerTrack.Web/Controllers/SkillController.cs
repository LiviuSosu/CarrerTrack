using AutoMapper;
using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarrerTrack.Web.Controllers
{
    public class SkillController : Controller
    {
        private readonly IAppCommandSkillService _skillCommandApp;
        private readonly IAppReadSkillService _skillReadApp;

       // private ILogging logger;
        //private ISimlarStrings similarStrings;

        public SkillController(IAppCommandSkillService skillCommandApp, IAppReadSkillService skillReadApp)
        {
            _skillReadApp = skillReadApp;
            _skillCommandApp = skillCommandApp;

          //  logger = new Logging();
         //   similarStrings = new SimilarStrings();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Skill>, IEnumerable<Model.Skill>>(_skillReadApp.GetAll()));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Model.Skill skill)
        {
            if(ModelState.IsValid)
            {
                _skillCommandApp.Add(Mapper.Map<Model.Skill,Skill>(skill));
                return RedirectToAction("Index", "Skill");
            }
            else
            {
                return View(skill);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Skill,Model.Skill>(_skillReadApp.GetById(id)));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(Model.Skill skill)
        {
            _skillCommandApp.Remove(skill.ID);
            return RedirectToAction("Index", "Skill");
        }
    }
}