using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanRMS.Models;

namespace HumanRMS.Controllers
{
    public class AdminController : Controller
    {
        HRMSEntities db=new HRMSEntities();
        // GET: Admin
        public ActionResult Dashboard()
        {
            
            TempData["name"] = "AmanUllah";
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
             //Count Attendances
            int countALLAttendances = (from row in db.attendances
                                       select row).Count();
            ViewBag.ALLAttendances = countALLAttendances;

             return View();
        }
        public void bager()
        {
            //ViewBag.Displayclint=db.employee_info.ToList();
            //ViewBag.Count = db.employee_info.Count();
            //ViewBag.Displayclint = db.Events.ToList();
            //ViewBag.Events.Count = db.Events.Count();
            //ViewBag.Displayclint = db.notice_info.ToList();
            //ViewBag.notice_info.Count = db.notice_info.Count();
            //ViewBag.Displayclint = db.attendances.ToList();
            //ViewBag.attendances.Count = db.attendances.Count();

        }
    }
}