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
    public class LeavesController : Controller
    {
        private HRMSEntities db = new HRMSEntities();

        // GET: Leaves
        public ActionResult Index()
        {
            var emp_leaves = db.emp_leaves.Include(e => e.attendance).Include(e => e.employee_info);
            return View(emp_leaves.ToList());
        }

        // GET: Leaves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp_leaves emp_leaves = db.emp_leaves.Find(id);
            if (emp_leaves == null)
            {
                return HttpNotFound();
            }
            return View(emp_leaves);
        }

        // GET: Leaves/Create
        public ActionResult Create()
        {
            ViewBag.leave_fk_att_id = new SelectList(db.attendances, "att_id", "att_work");
            ViewBag.leave_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname");
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "leave_id,leave_yearly,deducated_leave,remaining_leave,leave_fk_emp_id,leave_fk_att_id")] emp_leaves emp_leaves)
        {
            if (ModelState.IsValid)
            {
                db.emp_leaves.Add(emp_leaves);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.leave_fk_att_id = new SelectList(db.attendances, "att_id", "att_work", emp_leaves.leave_fk_att_id);
            ViewBag.leave_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname", emp_leaves.leave_fk_emp_id);
            return View(emp_leaves);
        }

        // GET: Leaves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp_leaves emp_leaves = db.emp_leaves.Find(id);
            if (emp_leaves == null)
            {
                return HttpNotFound();
            }
            ViewBag.leave_fk_att_id = new SelectList(db.attendances, "att_id", "att_work", emp_leaves.leave_fk_att_id);
            ViewBag.leave_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname", emp_leaves.leave_fk_emp_id);
            return View(emp_leaves);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "leave_id,leave_yearly,deducated_leave,remaining_leave,leave_fk_emp_id,leave_fk_att_id")] emp_leaves emp_leaves)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp_leaves).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.leave_fk_att_id = new SelectList(db.attendances, "att_id", "att_work", emp_leaves.leave_fk_att_id);
            ViewBag.leave_fk_emp_id = new SelectList(db.employee_info, "emp_id", "emp_fname", emp_leaves.leave_fk_emp_id);
            return View(emp_leaves);
        }

        // GET: Leaves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp_leaves emp_leaves = db.emp_leaves.Find(id);
            if (emp_leaves == null)
            {
                return HttpNotFound();
            }
            return View(emp_leaves);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emp_leaves emp_leaves = db.emp_leaves.Find(id);
            db.emp_leaves.Remove(emp_leaves);
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
