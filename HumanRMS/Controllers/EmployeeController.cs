using HumanRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace HumanRMS.Controllers
{
    

    public class EmployeeController : Controller
    {
        
        HRMSEntities db = new HRMSEntities();
        // GET: Employee
        public ActionResult Dashbord()
        {
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
        public ActionResult Attendance()
        {
            //id Attendance show

            return View();
        }
        public ActionResult AllEvents()
        {
            return View(db.Events.ToList());
        }
        public ActionResult AllNotice()
        {
            return View(db.notice_info.ToList());
        }
            
    }
}