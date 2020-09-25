using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetulBlogSiteDotNet.Controllers
{
    using Models;
    public class AdminController : Controller
    {
        B403BlogEntities context = new B403BlogEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YazarOnaylari()
        {
            var data = context.Kullanici.Where(x => x.Yazar == true && x.Onaylandı == false).ToList();

            return View(data);
        }
        public ActionResult OnayVer(int Id)
        {
            Kullanici k1 = context.Kullanici.FirstOrDefault(x => x.KullaniciId == Id);
            k1.Onaylandı = true;
            context.SaveChanges();

            return RedirectToAction("YazarOnaylari");
        }
    }
}