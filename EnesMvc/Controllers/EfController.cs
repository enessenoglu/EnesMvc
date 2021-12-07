using EnesMvc.Models;
using EnesMvc.Models.Manager;
using EnesMvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnesMvc.Controllers
{
    public class EfController : Controller
    {
        // GET: Ef
        public ActionResult Index()
        {
            PersonsDatabaseContext db = new PersonsDatabaseContext();
            // List<Persons> persons = db.Persons.ToList();
            PerAddViewModel model = new PerAddViewModel();
            model.Persons = db.Persons.ToList();
            model.Addresses = db.Addresses.ToList();
            return View(model);
        }
    }
}