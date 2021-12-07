using EnesMvc.Models.Manager;
using EnesMvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnesMvc.Controllers
{
    public class EfSchoolController : Controller
    {
        // GET: EfTeacher
        public ActionResult Index()
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            // List<Persons> persons = db.Persons.ToList();
            SchoolAddVeiwModel model = new SchoolAddVeiwModel();
            model.teachers = db.teachers.ToList();
            model.students = db.students.ToList();
            return View(model);
        }
    }
}