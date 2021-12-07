using EnesMvc.Models;
using EnesMvc.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnesMvc.Controllers
{
    public class EfstudentController : Controller
    {
        // GET: Efstudent
        public ActionResult Index()
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            List<Teachers> teachers = db.teachers.ToList();
            return View(teachers);
        }
        [HttpGet]
        public ActionResult FormSayfasi()
        {


            return View();
        }
        [HttpPost]
        public ActionResult FormSayfasi(FormCollection form)
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            Teachers teacher = new Teachers();
            teacher.Name = form["Name"].Trim();
            teacher.Surname = form["Surname"].Trim();
            teacher.Department = form["Department"].Trim();
            db.teachers.Add(teacher);
            db.SaveChanges();

            return RedirectToAction("Index","Efstudent");
        }

    }
}