using BetulBlogSiteDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BetulBlogSiteDotNet.Controllers
{
    public class KullaniciController : Controller
    {

        B403BlogEntities context = new B403BlogEntities();
        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Kullanici kl)
        {
            string ka = ValidateUser(kl.KullaniciAdi, kl.Parola);
            if (!string.IsNullOrEmpty(ka))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                    (1, kl.KullaniciAdi, DateTime.Now, DateTime.Now.AddMinutes(15), true, ka, FormsAuthentication.FormsCookiePath);
                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);
               if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;
                }
                
                Response.Cookies.Add(ck);

                
                FormsAuthentication.RedirectFromLoginPage(kl.KullaniciAdi, true);
                return RedirectToAction("GirisYap");
            }

            return RedirectToAction("GirisYap");
        }

        string ValidateUser(string ka,string pwd)
        {
            Kullanici kl = context.Kullanici.FirstOrDefault(x => x.KullaniciAdi == ka && x.Parola == pwd);
            if (kl != null)
                return kl.KullaniciAdi;
            else
            {

                return "";
            }
        }

        public ActionResult CikisYap(string redirectUrl)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(redirectUrl);
        }
        public ActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeOl(Kullanici k1,string rdBay,string rdBayan)
        {
            if (!string.IsNullOrEmpty(rdBay))
                k1.Cinsiyet = true;
            if (!string.IsNullOrEmpty(rdBayan))
                k1.Cinsiyet = false;
            k1.Yazar = false;
            k1.Onaylandı = true;
            k1.Aktif = true;

            k1.DogumTarihi =k1.DogumTarihi.Value.Date;
            k1.KayitTarihi = DateTime.Now;
            context.Kullanici.Add(k1);
            context.SaveChanges();
            return RedirectToAction("GirisYap");
        }
    }
}