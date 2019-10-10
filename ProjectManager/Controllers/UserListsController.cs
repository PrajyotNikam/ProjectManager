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
    public class UserListsController : Controller
    {
        private PMDBEntities db = new PMDBEntities();

        // GET: UserLists
        public ActionResult Index(string sortOrder, string currentFilter, string searchString)
        {
            //var userLists = db.UserLists.Include(u => u.ProjectList).Include(u => u.TaskList);
            //return View(userLists.ToList());
            ViewBag.Project = "Project";
            ViewBag.First_Name = "First_Name";
            ViewBag.Last_Name = "Last_Name";
            ViewBag.Employee_ID = "Employee_ID";
            ViewBag.Task = "Task";
            ViewBag.CurrentSort = currentFilter;

            var userDetails = from s in db.UserLists.Include(u => u.ProjectList).Include(u => u.TaskList)
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                userDetails = userDetails.Where(s => s.Last_Name.Contains(searchString)
                                       || s.First_Name.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "First_Name":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        userDetails = userDetails.OrderBy(s => s.First_Name);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        userDetails = userDetails.OrderByDescending(s => s.First_Name);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Last_Name":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        userDetails = userDetails.OrderBy(s => s.Last_Name);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        userDetails = userDetails.OrderByDescending(s => s.Last_Name);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Employee_ID":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        userDetails = userDetails.OrderBy(s => s.Employee_ID);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        userDetails = userDetails.OrderByDescending(s => s.Employee_ID);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Project":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        userDetails = userDetails.OrderBy(s => s.ProjectList.Project);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        userDetails = userDetails.OrderByDescending(s => s.ProjectList.Project);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Task":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        userDetails = userDetails.OrderBy(s => s.TaskList.Task);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        userDetails = userDetails.OrderByDescending(s => s.TaskList.Task);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                default:
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        userDetails = userDetails.OrderBy(s => s.Last_Name);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        userDetails = userDetails.OrderByDescending(s => s.Last_Name);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
            }
            return View(userDetails.ToList());
        }

        // GET: UserLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserList userList = db.UserLists.Find(id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            return View(userList);
        }

        // GET: UserLists/Create
        public ActionResult Create()
        {
            ViewBag.Project_ID = new SelectList(db.ProjectLists, "Project_ID", "Project");
            ViewBag.Task_ID = new SelectList(db.TaskLists, "Task_ID", "Task");
            return View();
        }

        // POST: UserLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,First_Name,Last_Name,Employee_ID,Project_ID,Task_ID")] UserList userList)
        {
            if (ModelState.IsValid)
            {
                db.UserLists.Add(userList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Project_ID = new SelectList(db.ProjectLists, "Project_ID", "Project", userList.Project_ID);
            ViewBag.Task_ID = new SelectList(db.TaskLists, "Task_ID", "Task", userList.Task_ID);
            return View(userList);
        }

        // GET: UserLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserList userList = db.UserLists.Find(id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            ViewBag.Project_ID = new SelectList(db.ProjectLists, "Project_ID", "Project", userList.Project_ID);
            ViewBag.Task_ID = new SelectList(db.TaskLists, "Task_ID", "Task", userList.Task_ID);
            return View(userList);
        }

        // POST: UserLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,First_Name,Last_Name,Employee_ID,Project_ID,Task_ID")] UserList userList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Project_ID = new SelectList(db.ProjectLists, "Project_ID", "Project", userList.Project_ID);
            ViewBag.Task_ID = new SelectList(db.TaskLists, "Task_ID", "Task", userList.Task_ID);
            return View(userList);
        }

        // GET: UserLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserList userList = db.UserLists.Find(id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            return View(userList);
        }

        // POST: UserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserList userList = db.UserLists.Find(id);
            db.UserLists.Remove(userList);
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
