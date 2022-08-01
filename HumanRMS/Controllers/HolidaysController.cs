using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HumanRMS.Models;

namespace HumanRMS.Controllers
{
    public class HolidaysController : Controller
    {
        private HRMSEntities db = new HRMSEntities();

        // GET: Holidays
        public ActionResult Index()
        {
            var holidays = db.holidays.Include(h => h.attendance).Include(h => h.employee_info);
            return View(holidays.ToList());
        }

        // GET: Holidays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            holiday holiday = db.holidays.Find(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            return View(holiday);
        }

        // GET: Holidays/Create
        public ActionResult Create()
        {
            ViewBag.holiday_fk_att_id = new SelectList(db.attendances, "att_id", "att_work");
            ViewBag.holiday_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname");
            return View();
        }

        // POST: Holidays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "holiday_id,holiday_month,holiday_day,holiday_year,holiday_description,holiday_fk_emp_id,holiday_fk_att_id")] holiday holiday)
        {
            if (ModelState.IsValid)
            {
                db.holidays.Add(holiday);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.holiday_fk_att_id = new SelectList(db.attendances, "att_id", "att_work", holiday.holiday_fk_att_id);
            ViewBag.holiday_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname", holiday.holiday_fk_emp_id);
            return View(holiday);
        }

        // GET: Holidays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            holiday holiday = db.holidays.Find(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            ViewBag.holiday_fk_att_id = new SelectList(db.attendances, "att_id", "att_work", holiday.holiday_fk_att_id);
            ViewBag.holiday_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname", holiday.holiday_fk_emp_id);
            return View(holiday);
        }

        // POST: Holidays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "holiday_id,holiday_month,holiday_day,holiday_year,holiday_description,holiday_fk_emp_id,holiday_fk_att_id")] holiday holiday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holiday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.holiday_fk_att_id = new SelectList(db.attendances, "att_id", "att_work", holiday.holiday_fk_att_id);
            ViewBag.holiday_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname", holiday.holiday_fk_emp_id);
            return View(holiday);
        }

        // GET: Holidays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            holiday holiday = db.holidays.Find(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            return View(holiday);
        }

        // POST: Holidays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            holiday holiday = db.holidays.Find(id);
            db.holidays.Remove(holiday);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
