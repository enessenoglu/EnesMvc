using EnesMvc.Models;
using EnesMvc.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnesMvc.Controllers
{
    public class StudentsController : Controller
    {
        public ActionResult NewStudent()
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            List<SelectListItem> teacherList = (from s in db.teachers
                                               select new SelectListItem()
                                               {
                                                   Text = s.Name + " " + s.Surname,
                                                   Value = s.Id.ToString()
                                               }).ToList();
            //List<Persons> persons = db.Persons.ToList();
            //List<SelectListItem> personsList = new List<SelectListItem>();
            //foreach (Persons person in persons)
            //{
            //    SelectListItem item = new SelectListItem();
            //    item.Text = person.Name + "  " + person.Surname;
            //    item.Value = person.Id.ToString();
            //    personsList.Add(item);
            //}
            TempData["teachers"] = teacherList;
            ViewBag.teachers = teacherList;

            return View();
        }
        [HttpPost]
        public ActionResult NewStudent(Students students)
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            Teachers teachers = db.teachers.FirstOrDefault(x => x.Id == students.Teachers.Id);
            if (teachers != null)
            {
                students.Teachers = teachers;
                db.students.Add(students);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Student enrollment complated Successfully.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Student enrollment complated failure.";
                    ViewBag.Status = "danger";
                }

            }
            ViewBag.teachers = TempData["teachers"];
            return View();
        }
    }
}