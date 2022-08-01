using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HumanRMS.Models;

namespace HumanRMS.Controllers
{
    
    public class employee_infoController : Controller
    {
        private HRMSEntities db = new HRMSEntities();

        // GET: employee_info
        public ActionResult Index(string searching)
        {

            int countALLEmployee = (from row in db.employee_info
                                    select row).Count();
            ViewBag.ALLEmployee = countALLEmployee;
            return View(db.employee_info.ToList());
        }

        // GET: employee_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_info employee_info = db.employee_info.Find(id);
            if (employee_info == null)
            {
                return HttpNotFound();
            }
            return View(employee_info);
        }

        // GET: employee_info/Create
        public ActionResult Create()
        {
            employee_info info = new employee_info();
            
            return View();
        }

        // POST: employee_info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_id,emp_fname,emp_lname,emp_cnic,emp_salary,emp_gender,emp_email,emp_mobile")] employee_info employee_info)
        {
            if (ModelState.IsValid)
            {
                db.employee_info.Add(employee_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.Clear();
            return View(employee_info);
            
        }

        // GET: employee_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_info employee_info = db.employee_info.Find(id);
            if (employee_info == null)
            {
                return HttpNotFound();
            }
            return View(employee_info);
        }

        // POST: employee_info/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,emp_fname,emp_lname,emp_cnic,emp_salary,emp_gender,emp_email,emp_mobile,emp_image,ImageFile")] employee_info employee_info)
        {

            if(ModelState.IsValid)
            {
                db.Entry(employee_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee_info);
        }

        // GET: employee_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_info employee_info = db.employee_info.Find(id);
            if (employee_info == null)
            {
                return HttpNotFound();
            }
            return View(employee_info);
        }

        // POST: employee_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee_info employee_info = db.employee_info.Find(id);
            db.employee_info.Remove(employee_info);
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
        public void bager()
        {
            ViewBag.Displayclint = db.employee_info.ToList();
            ViewBag.Count = db.employee_info.Count();

        }
    }
}
