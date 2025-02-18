using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CVProje2.Models.entity;

namespace CVProje2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            CVDbEntities db = new CVDbEntities();
            var bilgi = db.TblAdmin.FirstOrDefault(x=>x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if(bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Anasayfa");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}