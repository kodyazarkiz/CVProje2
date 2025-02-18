using CVProje2.Models.entity;
using CVProje2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVProje2.Controllers
{
    public class ProjeController : Controller
    {
        // GET: Proje
        GenericRepository<TblProjeler> repo = new GenericRepository<TblProjeler>();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult ProjeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjeEkle(TblProjeler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult ProjeSil(int id)
        {
            TblProjeler t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProjeGetir(int id)
        {
            TblProjeler t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult ProjeGetir(TblProjeler p)
        {
            TblProjeler t = repo.Find(x => x.ID == p.ID);
            t.Resim = p.Resim;
            t.Kategori = p.Kategori;
            t.Bağlantı = p.Bağlantı;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}