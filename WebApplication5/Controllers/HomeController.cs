using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        Model2 db = new Model2();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Kullanici()
        {
            return View(db.CUSTOMERS.ToList());
        }
        [HttpPost]
        public ActionResult Kullanici(CUSTOMERS getUser)
        {
            db.CUSTOMERS.Add(getUser);
            db.SaveChanges();
            return View(db.CUSTOMERS.ToList());
        }

        [HttpGet]
        public ActionResult KullaniciDuzenle(int id)
        {
            CUSTOMERS tempID = db.CUSTOMERS.Where(k=> k.ID == id).SingleOrDefault();
            return View(tempID);
        }
        [HttpPost]
        public ActionResult KullaniciDuzenle(CUSTOMERS getUser)
        {
            CUSTOMERS tempID = db.CUSTOMERS.Where(k => k.ID == getUser.ID).SingleOrDefault();
            tempID.CUSTOMERNAME = getUser.CUSTOMERNAME;
            tempID.AGE = getUser.AGE;
            tempID.GENDER = getUser.GENDER;
            tempID.EMAIL = getUser.EMAIL;
            tempID.PASSWORD = getUser.PASSWORD;
            db.SaveChanges();
            return RedirectToAction("Kullanici");
        }
        public ActionResult KullaniciSil(int id)
        {
            CUSTOMERS tempID = db.CUSTOMERS.Where(k => k.ID == id).FirstOrDefault();
            db.CUSTOMERS.Remove(tempID);
            db.SaveChanges();
            return RedirectToAction("Kullanici","Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult LogOut()
        {
            Session["Security"] = false;
            Session.Abandon();
            return RedirectToAction("Index", "HomePage");
        }
    }
}