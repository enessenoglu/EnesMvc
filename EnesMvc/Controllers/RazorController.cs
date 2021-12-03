using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnesMvc.Controllers
{
    public class RazorController : Controller
    {
        // GET: Razor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();

        }
        public ActionResult Index4()
        {
            ViewBag.Text1 = "<script type='text / javascript'>alert('Merhaba Mvc')</script>";
            ViewData["AdSoyad"] = "Enes Şenoğlu";
            TempData["memleketi"]="Samsun";
            return View();
          

        }
        public ActionResult Index5()
        {
            ViewBag.isim = "Enes Şenoğlu";
            ViewBag.check = true;
            ViewBag.list = new SelectListItem[]
            {
                new SelectListItem() {Text="İsmail"},
                 new SelectListItem() {Text="Hüseyin"},
                  new SelectListItem() {Text="Nurten"},
                  new SelectListItem() {Text="Nurettin"}
            };



            return View();
        }  
        public ActionResult Index6()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index6(string text1,bool check1,string list1)
        {
            var t1 = Request.Form["text1"];
            var c1 = Request.Form.GetValues("check1")[0];
            var l1 = Request.Form["list1"];
            return View("Index7");

        }
        [HttpGet]
        public ActionResult Index7()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index7(string a)
        {
            return View("Index6");
        }
    }
}