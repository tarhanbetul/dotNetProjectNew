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
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult KategoriWidget()
        {
            return PartialView(context.Kategori.ToList());
        }
    }
}