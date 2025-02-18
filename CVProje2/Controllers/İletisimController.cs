using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProje2.Models.entity;
using CVProje2.Repositories;

namespace CVProje2.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim
        GenericRepository<Tbliletisim> repo = new GenericRepository<Tbliletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}