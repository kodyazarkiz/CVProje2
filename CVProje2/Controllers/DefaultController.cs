using CVProje2.Models.entity;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVProje2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        CVDbEntities db = new CVDbEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sosyalmedya);
        }

        [AllowAnonymous]
        public PartialViewResult Anasayfa()
        {
            var anasayfa = db.TblAnasayfa.ToList();
            return PartialView(anasayfa);
        }
        [AllowAnonymous]
        public PartialViewResult Hakkimda()
        {
            var hakkimda = db.TblHakkimdaa.ToList();
            return PartialView(hakkimda);
        }
        [AllowAnonymous]
        public PartialViewResult EgitimDeneyim()
        {
            var egitimdeneyim = db.TblEğitimDeneyim.ToList();
            return PartialView(egitimdeneyim);
        }
        [AllowAnonymous]
        public PartialViewResult Projeler()
        {
            var projeler = db.TblProjeler.ToList();
            return PartialView(projeler);
        }
        [AllowAnonymous]
        public PartialViewResult Blog()
        {
            var blog = db.TblBlog.ToList();
            return PartialView(blog);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult İletisim()
        {
            var iletisim = db.Tbliletisim.ToList();
            return PartialView(iletisim);
        }

        [HttpPost]
        public PartialViewResult İletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}