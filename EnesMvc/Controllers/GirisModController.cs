using EnesMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnesMvc.Models;
using EnesMvc.ViewModel;

namespace EnesMvc.Controllers
{
    public class GirisModController : Controller
    {
        // GET: GirisMod
        [HttpGet]
        public ActionResult Index()
        {
            Kisi kisi = new Kisi();
            kisi.Ad = "";
            kisi.Soyad = "";
            kisi.Yas = 0;
            Adres adres = new Adres();
            adres.AdresTanimi = "";
            adres.Sehir = "";
            indexViewModel mod = new indexViewModel();
            mod.AdresNesnesi = adres;
            mod.KisiNesnesi = kisi;




            return View(mod);
        }
        [HttpPost]
        public ActionResult Index(indexViewModel model)
        {
            return View(model);
        }
    }
}