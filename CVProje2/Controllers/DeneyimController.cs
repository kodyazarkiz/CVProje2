using CVProje2.Models.entity;
using CVProje2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVProje2.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblEğitimDeneyim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblEğitimDeneyim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblEğitimDeneyim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TblEğitimDeneyim p)
        {
            TblEğitimDeneyim t = repo.Find(x => x.ID == p.ID);
            t.DBaslik = p.DBaslik;
            t.Pozisyon = p.Pozisyon;
            t.DTarih = p.DTarih;
            t.DAciklama = p.DAciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}