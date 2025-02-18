using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProje2.Models.entity;
using CVProje2.Repositories;

namespace CVProje2.Controllers
{
    [AllowAnonymous]
    public class KullanıcıController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult KullaniciEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciEkle(TblAdmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Düzenle(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Düzenle(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}