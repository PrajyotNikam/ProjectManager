using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class ParentTasksController : Controller
    {
        private PMDBEntities db = new PMDBEntities();

        // GET: ParentTasks
        public ActionResult Index()
        {
            return View(db.ParentTasks.ToList());
        }

        // GET: ParentTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentTask parentTask = db.ParentTasks.Find(id);
            if (parentTask == null)
            {
                return HttpNotFound();
            }
            return View(parentTask);
        }

        // GET: ParentTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParentTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Parent_ID,Parent_Task")] ParentTask parentTask)
        {
            if (ModelState.IsValid)
            {
                db.ParentTasks.Add(parentTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parentTask);
        }


        public ActionResult CreateParentTask([Bind(Include = "Parent_ID,Parent_Task")] ParentTask parentTask)
        {
            if (ModelState.IsValid)
            {
                db.ParentTasks.Add(parentTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parentTask);
        }
        // GET: ParentTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentTask parentTask = db.ParentTasks.Find(id);
            if (parentTask == null)
            {
                return HttpNotFound();
            }
            return View(parentTask);
        }

        // POST: ParentTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Parent_ID,Parent_Task")] ParentTask parentTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parentTask);
        }

        // GET: ParentTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentTask parentTask = db.ParentTasks.Find(id);
            if (parentTask == null)
            {
                return HttpNotFound();
            }
            return View(parentTask);
        }

        // POST: ParentTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParentTask parentTask = db.ParentTasks.Find(id);
            db.ParentTasks.Remove(parentTask);
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
