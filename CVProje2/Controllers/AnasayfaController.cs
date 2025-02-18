using CVProje2.Models.entity;
using CVProje2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVProje2.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        AnasayfaRepository repo = new AnasayfaRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        public ActionResult AnasayfaSil(int id)
        {
            TblAnasayfa t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AnasayfaGetir(int id)
        {
            TblAnasayfa t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult AnasayfaGetir(TblAnasayfa p)
        {
            TblAnasayfa t = repo.Find(x => x.ID == p.ID);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Baslik = p.Baslik;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}