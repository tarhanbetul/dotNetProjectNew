using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
namespace BetulBlogSiteDotNet.Controllers
{
    using Models;
    using System.Runtime.Remoting.Contexts;

    public class HomeController : Controller
    {
        // GET: Home
        B403BlogEntities context = new B403BlogEntities();
        public ActionResult Index()
        {
            
            return View();
        }

        public PartialViewResult MakaleListeleWidget()
        {
            return PartialView(context.Makale.ToList());
        }

        public PartialViewResult PopulerMakalelerWidget()
        {
            var model = context.Makale.OrderByDescending
                (x => x.EklenmeTarihi).Take(3).ToList();
            return PartialView();
        }
    }
}//numantest