using EnesMvc.Models;
using EnesMvc.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnesMvc.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult NewPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPerson(Persons persons)
        {
            PersonsDatabaseContext db = new PersonsDatabaseContext();
            db.Persons.Add(persons);
            int result = db.SaveChanges();
            if (result>0)
            {
                ViewBag.Result = "Person enrollment complated Successfully.";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Person enrollment complated failure.";
                ViewBag.Status = "danger";
            }
            ModelState.Clear();
            return View();
        }
    }
}