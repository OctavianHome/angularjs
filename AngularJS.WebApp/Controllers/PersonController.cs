using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularJS.Repository.Generic;
using AngularJS.Model.Model;

namespace AngularJS.WebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _repository;

        //inject dependency
        public PersonController(IPersonRepository repository)
        {

            this._repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public JsonResult getAll()
        {
            var data = _repository.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get(int personId)
        {
            var person = _repository.Edit(personId);
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        public string Update(Person p)
        {
            var person = new Person {Name = p.Name, Revenue = p.Revenue, Comment = p.Comment};
            return "Person Updated";
        }
    }
}
