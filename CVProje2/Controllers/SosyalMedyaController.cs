using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProje2.Models.entity;
using CVProje2.Repositories;

namespace CVProje2.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya> ();
        CVDbEntities db = new CVDbEntities ();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Düzenle(int id)
        {
            var hesap = repo.Find(x=>x.ID == id);
            return View(hesap);
        }

        [HttpPost]
        public ActionResult Düzenle(TblSosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.Ad = p.Ad;
            hesap.Durum = p.Durum;
            hesap.Link = p.Link;
            hesap.İkon = p.İkon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x=>x.ID==id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}