using EnesMvc.Models;
using EnesMvc.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnesMvc.Controllers
{
    public class TeachersController : Controller
    {
        // GET: Teachers
        public ActionResult NewTeacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewTeacher(Teachers teachers)
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            db.teachers.Add(teachers);
            int result = db.SaveChanges();
            if (result > 0)
            {
                ViewBag.Result = "Teacher enrollment complated Successfully.";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Teacher enrollment complated failure.";
                ViewBag.Status = "danger";
            }
            ModelState.Clear();
            return View();
           
        }

    }
}