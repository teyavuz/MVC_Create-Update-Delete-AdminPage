using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaseStudyProject.Models.Entity;

namespace CaseStudyProject.Controllers
{
    public class UsersController : Controller
    {
        private IsBasvuruEntities db = new IsBasvuruEntities();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProfilePhoto,Name,Surname,Mission,Phone,Mail,Adress,About,Experience,Studies,Skills,Refs,Hobies,Certificiate")] Users users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(users);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }

                return View(users);
            }
            catch
            {
                

                return View("Create");
            }
            
        }

    }
}
