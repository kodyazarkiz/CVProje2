using CVProje2.Models.entity;
using CVProje2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVProje2.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        GenericRepository<TblBlog> repo = new GenericRepository<TblBlog>();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult BlogEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BlogEkle(TblBlog p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            TblBlog t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BlogGetir(int id)
        {
            TblBlog t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult BlogGetir(TblBlog p)
        {
            if (!ModelState.IsValid)
            {
                return View("BlogGetir");
            }
            TblBlog t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.Kategori = p.Kategori;
            t.Tarih = p.Tarih;
            t.Resim = p.Resim;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}