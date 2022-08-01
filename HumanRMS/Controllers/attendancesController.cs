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
    public class attendancesController : Controller
    {
        private HRMSEntities db = new HRMSEntities();

        // GET: attendances
        public ActionResult Index()
        {
            int countALLAttendances = (from row in db.attendances
                                       select row).Count();
            ViewBag.ALLAttendances = countALLAttendances;
            var attendances = db.attendances.Include(a => a.employee_info);
            return View(attendances.ToList());
        }

        // GET: attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: attendances/Create
        public ActionResult Create()
        {
            ViewBag.att_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname");
            return View();
        }

        // POST: attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "att_id,att_date,att_clock_in,att_clock_out,att_fk_emp_id,att_work")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.att_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname", attendance.att_fk_emp_id);
            return View(attendance);
        }

        // GET: attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.att_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname", attendance.att_fk_emp_id);
            return View(attendance);
        }

        // POST: attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "att_id,att_date,att_clock_in,att_clock_out,att_fk_emp_id,att_work")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.att_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname", attendance.att_fk_emp_id);
            return View(attendance);
        }

        // GET: attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attendance attendance = db.attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            attendance attendance = db.attendances.Find(id);
            db.attendances.Remove(attendance);
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
