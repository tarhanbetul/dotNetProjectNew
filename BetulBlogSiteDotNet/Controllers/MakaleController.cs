using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace BetulBlogSiteDotNet.Controllers
{
    using Models;
    [Authorize]
    public class MakaleController : Controller

    {
        B403BlogEntities context = new B403BlogEntities();
        // GET: Makale
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Detay(int id)
        {
            var data = context.Makale.FirstOrDefault(x => x.MakaleId == id);
            return View(data);
        } 

        [Authorize(Roles="Admin")]
        public ActionResult MakaleEkle()
        {
            return View();
        }
    }
}