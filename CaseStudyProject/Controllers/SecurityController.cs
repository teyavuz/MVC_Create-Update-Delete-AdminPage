using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudyProject.Models.Entity;
using System.Web.Security;

namespace CaseStudyProject.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        IsBasvuruEntities db = new IsBasvuruEntities();
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Logins login)
        {
            var bilgiler = db.Logins.FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);
            if (bilgiler!= null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Username,false);
                Session["Username"] = bilgiler.Username; 
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
            
        }
    }
}