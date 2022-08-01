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
    public class noticeController : Controller
    {
        private HRMSEntities db = new HRMSEntities();

        // GET: notice
        public ActionResult Index()
        {
            return View(db.notice_info.ToList());
        }

        // GET: notice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice_info notice_info = db.notice_info.Find(id);
            if (notice_info == null)
            {
                return HttpNotFound();
            }
            return View(notice_info);
        }

        // GET: notice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "notice_id,notice_subject,notice_date,notice_time,notice_dis")] notice_info notice_info)
        {
            if (ModelState.IsValid)
            {
                db.notice_info.Add(notice_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notice_info);
        }

        // GET: notice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice_info notice_info = db.notice_info.Find(id);
            if (notice_info == null)
            {
                return HttpNotFound();
            }
            return View(notice_info);
        }

        // POST: notice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "notice_id,notice_subject,notice_date,notice_time,notice_dis")] notice_info notice_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notice_info);
        }

        // GET: notice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice_info notice_info = db.notice_info.Find(id);
            if (notice_info == null)
            {
                return HttpNotFound();
            }
            return View(notice_info);
        }

        // POST: notice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notice_info notice_info = db.notice_info.Find(id);
            db.notice_info.Remove(notice_info);
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
