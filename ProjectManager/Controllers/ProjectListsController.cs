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
    public class ProjectListsController : Controller
    {
        private PMDBEntities db = new PMDBEntities();

        // GET: ProjectLists
        public ActionResult Index(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.Project = "Project";
            ViewBag.Start_Date = "Start_Date";
            ViewBag.End_Date = "End_Date";
            ViewBag.Priority = "Priority";
            ViewBag.CurrentSort = currentFilter;

            var projectDetails = from s in db.ProjectLists
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                projectDetails = projectDetails.Where(s => s.Project.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "Project":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        projectDetails = projectDetails.OrderBy(s => s.Project);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        projectDetails = projectDetails.OrderByDescending(s => s.Project);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Start_Date":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        projectDetails = projectDetails.OrderBy(s => s.Start_Date);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        projectDetails = projectDetails.OrderByDescending(s => s.Start_Date);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "End_Date":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        projectDetails = projectDetails.OrderBy(s => s.End_Date);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        projectDetails = projectDetails.OrderByDescending(s => s.End_Date);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Priority":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        projectDetails = projectDetails.OrderBy(s => s.Priority);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        projectDetails = projectDetails.OrderByDescending(s => s.Priority);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                default:
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        projectDetails = projectDetails.OrderBy(s => s.Project);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        projectDetails = projectDetails.OrderByDescending(s => s.Project);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
            }
            return View(projectDetails.ToList());
        }

        // GET: ProjectLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectList projectList = db.ProjectLists.Find(id);
            if (projectList == null)
            {
                return HttpNotFound();
            }
            return View(projectList);
        }

        // GET: ProjectLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_ID,Project,Start_Date,End_Date,Priority")] ProjectList projectList)
        {
            if (projectList.Start_Date == null)
                projectList.Start_Date = DateTime.Today;
            if (projectList.End_Date == null)
                projectList.End_Date = DateTime.Today.AddDays(1);
            if (ModelState.IsValid)
            {
                db.ProjectLists.Add(projectList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectList);
        }

        // GET: ProjectLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectList projectList = db.ProjectLists.Find(id);
            if (projectList == null)
            {
                return HttpNotFound();
            }
            return View(projectList);
        }

        // POST: ProjectLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_ID,Project,Start_Date,End_Date,Priority")] ProjectList projectList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectList);
        }

        // GET: ProjectLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectList projectList = db.ProjectLists.Find(id);
            if (projectList == null)
            {
                return HttpNotFound();
            }
            return View(projectList);
        }

        // POST: ProjectLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectList projectList = db.ProjectLists.Find(id);
            //db.ProjectLists.Remove(projectList);
            //db.SaveChanges();
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
