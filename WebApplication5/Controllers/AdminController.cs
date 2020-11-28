using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class AdminController : Controller
    {
        Model2 db = new Model2();
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(string EMAIL, string PASSWORD)
        {
            CUSTOMERS tempUser = db.CUSTOMERS.Where(k => k.EMAIL == EMAIL && k.PASSWORD.Trim() == PASSWORD.Trim()).SingleOrDefault();
            if(tempUser == null)
            {
                ViewBag.Sonuc = "Kullanıcı bulunamadı.";
                return View();
            }
            else
            {
                Session["CUSTOMERS"] = tempUser.CUSTOMERNAME;
                Session["Security"] = true;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(string CUSTOMERNAME,string EMAIL, string PASSWORD, string pswrepeat,int AGE,string GENDER)
        {
            if (PASSWORD == pswrepeat)
            {
                var x = new CUSTOMERS();
                x.CUSTOMERNAME = CUSTOMERNAME;
                x.AGE = AGE;
                x.GENDER = GENDER;
                x.EMAIL = EMAIL;
                x.PASSWORD = PASSWORD;
                db.CUSTOMERS.Add(x);
                db.SaveChanges();
                ViewBag.Basarili = "Üyeliğiniz tamamlanmıştır.";
                return RedirectToAction("Index","Admin");
            }
            else
            {
                ViewBag.Basarili = "Üyeliğiniz tamamlanamamıştır.";
                return View();
            }
        }



    }
}