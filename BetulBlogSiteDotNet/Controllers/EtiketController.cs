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
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult EtiketlerWidget()
        {
            return PartialView(context.Etiket.ToList());
        }
    }
}