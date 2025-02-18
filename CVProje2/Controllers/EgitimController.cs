using CVProje2.Models.entity;
using CVProje2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVProje2.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEğitimDeneyim> repo = new GenericRepository<TblEğitimDeneyim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEğitimDeneyim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            TblEğitimDeneyim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            TblEğitimDeneyim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EgitimGetir(TblEğitimDeneyim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            TblEğitimDeneyim t = repo.Find(x => x.ID == p.ID);
            t.EBaslik = p.EBaslik;
            t.ETarih = p.ETarih;
            t.GNO = p.GNO;
            t.EAciklama = p.EAciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}