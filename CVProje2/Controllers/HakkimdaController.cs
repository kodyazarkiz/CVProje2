using CVProje2.Models.entity;
using CVProje2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVProje2.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        HakkimdaRepository repo = new HakkimdaRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        public ActionResult HakkimdaSil(int id)
        {
            TblHakkimdaa t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HakkimdaGetir(int id)
        {
            TblHakkimdaa t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult HakkimdaGetir(TblHakkimdaa p)
        {
            TblHakkimdaa t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.Aciklama = p.Aciklama;
            t.AdSoyad = p.AdSoyad;
            t.Yas = p.Yas;
            t.Dil = p.Dil;
            t.Telefon = p.Telefon;
            t.Mail = p.Mail;
            t.Adres = p.Adres;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}