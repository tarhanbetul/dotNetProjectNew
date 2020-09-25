using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetulBlogSiteDotNet.Controllers
{
    using Models;
    public class KategoriController : Controller
    {

        // GET: Kategori
        B403BlogEntities context = new B403BlogEntities();
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult KategoriWidget()
        {
            return PartialView(context.Kategori.ToList());
        }

        public ActionResult MakaleListele(int id)
        {
            var data = context.Makale.Where(x => x.KategoriID == id).ToList();
            return View("MakaleListeleWidget", data);
        }
    }
}