using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetulBlogSiteDotNet.Controllers
{
    using Models;
    using System.Runtime.Remoting.Contexts;

    public class EtiketController : Controller
    {
        // GET: Etiket
        B403BlogEntities context = new B403BlogEntities();
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult EtiketlerWidget()
        {
            return PartialView(context.Etiket.ToList());
        }
        public ActionResult MakaleListele(int id)
        {
            var data = context.Makale.Where(x => x.Etiket.Any(y => y.EtiketId == id)).ToList();

            return View("MakaleListeleWidget", data);
        }
    }
}