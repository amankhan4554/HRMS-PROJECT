using HumanRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanRMS.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        
        HRMSEntities db = new HRMSEntities();
        // GET: login
        public ActionResult Index()
        {
            TempData["institute"] = "Alfa Origen";
            //Count Employee
            int countALLEmployee = (from row in db.employee_info
                                    select row).Count();
            ViewBag.ALLEmployee = countALLEmployee;
            //Count Events
            int countALLEvents = (from row in db.Events
                                  select row).Count();
            ViewBag.ALLEvents = countALLEvents;
            //Count Notice
            int countALLNotice = (from row in db.notice_info
                                  select row).Count();
            ViewBag.ALLNotice = countALLNotice;

            return View();
        }
        public ActionResult Services()
        {
            TempData["name"] = "AmanUllah";
            return View();
        }
        public ActionResult About()
        {
            TempData["name"] = "AmanUllah";
            return View();
        }
        public ActionResult Project()
        {
            TempData["name"] = "AmanUllah";
            return View();
        }
        public ActionResult Help()
        {
            TempData["name"] = "AmanUllah";
            return View();
        }
    }
}