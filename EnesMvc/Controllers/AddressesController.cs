using EnesMvc.Models;
using EnesMvc.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnesMvc.Controllers
{
    public class AddressesController : Controller
    {
        // GET: Addresses
        public ActionResult NewAddress()
        {
            PersonsDatabaseContext db = new PersonsDatabaseContext();
            List<SelectListItem> personList = (from s in db.Persons
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
            TempData["persons"] = personList;
            ViewBag.persons = personList;

            return View();
        }
        [HttpPost]
        public ActionResult NewAddress(Addresses addresses)
        {
            PersonsDatabaseContext db = new PersonsDatabaseContext();
            Persons persons = db.Persons.FirstOrDefault(x => x.Id == addresses.Persons.Id);
            if (persons!=null)
            {
                addresses.Persons = persons;
                db.Addresses.Add(addresses);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Address enrollment complated Successfully.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Address enrollment complated failure.";
                    ViewBag.Status = "danger";
                }

            }
            ViewBag.persons = TempData["persons"];
            return View();
        }
    }
}