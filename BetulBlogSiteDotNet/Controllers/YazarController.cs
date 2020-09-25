using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetulBlogSiteDotNet.Controllers
{
    using Models;
    public class YazarController : Controller
    {
        B403BlogEntities context = new B403BlogEntities();
        // GET: Yazar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YazarOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarOl(Kullanici k1, string rdBay,string rdBayan)
        {
            if (!string.IsNullOrEmpty(rdBay))
                k1.Cinsiyet = true;
            if (!string.IsNullOrEmpty(rdBayan))
                k1.Cinsiyet = false;

            k1.Yazar = true;
            k1.Onaylandı = false;
            k1.Aktif = true;
            k1.KayitTarihi = DateTime.Now;
            context.Kullanici.Add(k1);
            context.SaveChanges();

            Rol yazar = context.Rol.FirstOrDefault(x => x.RolAdi == "Yazar");
            KullaniciRol kr = new KullaniciRol();
           
            kr.KullaniciID = k1.KullaniciId;
            kr.RolID = k1.RolId;
            context.KullaniciRol.Add(kr);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");


        
        }
    }
}