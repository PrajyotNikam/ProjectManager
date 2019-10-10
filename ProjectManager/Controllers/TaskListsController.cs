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
    public class TaskListsController : Controller
    {
        private PMDBEntities db = new PMDBEntities();        

        // GET: TaskLists
        public ActionResult Index(string sortOrder, string currentFilter, string searchString)
        {
            //var taskLists = db.TaskLists.Include(t => t.ParentTask);
            //return View(taskLists.ToList());
            ViewBag.Project = "Project";
            ViewBag.Task = "Task";
            ViewBag.Start_Date = "Start_Date";
            ViewBag.End_Date = "End_Date";
            ViewBag.Priority = "Priority";
            ViewBag.Status = "Status";
            ViewBag.Parent_Task = "Parent_Task";
            ViewBag.CurrentSort = currentFilter;

            var taskDetails = from s in db.TaskLists.Include(t => t.ParentTask)
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                taskDetails = taskDetails.Where(s => s.Task.Contains(searchString)
                                                  || s.ParentTask.Parent_Task.Contains(searchString)
                                                  || s.ProjectList.Project.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "Project":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        taskDetails = taskDetails.OrderBy(s => s.ProjectList.Project);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        taskDetails = taskDetails.OrderByDescending(s => s.ProjectList.Project);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Task":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        taskDetails = taskDetails.OrderBy(s => s.Task);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        taskDetails = taskDetails.OrderByDescending(s => s.Task);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Start_Date":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        taskDetails = taskDetails.OrderBy(s => s.Start_Date);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        taskDetails = taskDetails.OrderByDescending(s => s.Start_Date);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "End_Date":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        taskDetails = taskDetails.OrderBy(s => s.End_Date);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        taskDetails = taskDetails.OrderByDescending(s => s.End_Date);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Priority":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        taskDetails = taskDetails.OrderBy(s => s.Priority);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        taskDetails = taskDetails.OrderByDescending(s => s.Priority);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Status":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        taskDetails = taskDetails.OrderBy(s => s.Status);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        taskDetails = taskDetails.OrderByDescending(s => s.Status);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                case "Parent_Task":
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        taskDetails = taskDetails.OrderBy(s => s.ParentTask.Parent_Task);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        taskDetails = taskDetails.OrderByDescending(s => s.ParentTask.Parent_Task);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
                default:
                    if (ViewBag.CurrentSort == null || ViewBag.CurrentSort == "asc")
                    {
                        taskDetails = taskDetails.OrderBy(s => s.Task);
                        ViewBag.CurrentSort = "desc";
                    }
                    else
                    {
                        taskDetails = taskDetails.OrderByDescending(s => s.Task);
                        ViewBag.CurrentSort = "asc";
                    }
                    break;
            }
            return View(taskDetails.ToList());
        }

        // GET: TaskLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList taskList = db.TaskLists.Find(id);
            if (taskList == null)
            {
                return HttpNotFound();
            }
            return View(taskList);
        }

        // GET: TaskLists/Create
        public ActionResult Create()
        {
            ViewBag.Parent_ID = new SelectList(db.ParentTasks, "Parent_ID", "Parent_ID");
            ViewBag.Project_ID = new SelectList(db.ProjectLists, "Project_ID", "Project_ID");
            ViewBag.Parent_Task = new SelectList(db.ParentTasks, "Parent_Task", "Parent_Task");
            ViewBag.Project = new SelectList(db.ProjectLists, "Project", "Project");
            return View();
        }

        // POST: TaskLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Task_ID,Parent_ID,Parent_Task,Project_ID,Project,Task,isParentTask,Start_Date,End_Date,Priority,Status")] TaskList taskList)
        {
            if (taskList.Project != null)
                taskList.Project_ID = db.ProjectLists.Where(m => m.Project == taskList.Project).FirstOrDefault().Project_ID;

            if (taskList.Parent_Task != null)
                taskList.Parent_ID = db.ParentTasks.Where(m => m.Parent_Task == taskList.Parent_Task).FirstOrDefault().Parent_ID;

            if (taskList.Start_Date == null)
                taskList.Start_Date = DateTime.Today;

            if (taskList.End_Date == null)
                taskList.End_Date = DateTime.Today.AddDays(1);

            if (taskList.Status == null)
                taskList.Status = true;
            

            if (taskList.isParentTask)
            {
                ParentTask parentTask = new ParentTask();                
                parentTask.Parent_ID = 0;
                parentTask.Parent_Task = taskList.Task;
                return RedirectToAction("CreateParentTask", "ParentTasks",parentTask);
            }

            else
            {
                if (ModelState.IsValid)
                {
                    db.TaskLists.Add(taskList);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Parent_ID = new SelectList(db.ParentTasks, "Parent_ID", "Parent_ID");
            ViewBag.Project_ID = new SelectList(db.ProjectLists, "Project_ID", "Project_ID");
            ViewBag.Parent_Task = new SelectList(db.ParentTasks, "Parent_Task", "Parent_Task");
            ViewBag.Project = new SelectList(db.ProjectLists, "Project", "Project");
            return View(taskList);
        }

        // GET: TaskLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList taskList = db.TaskLists.Find(id);
            if (taskList == null)
            {
                return HttpNotFound();
            }
            ViewBag.Parent_ID = new SelectList(db.ParentTasks, "Parent_ID", "Parent_ID");
            ViewBag.Project_ID = new SelectList(db.ProjectLists, "Project_ID", "Project_ID");
            ViewBag.Parent_Task = new SelectList(db.ParentTasks, "Parent_Task", "Parent_Task");
            ViewBag.Project = new SelectList(db.ProjectLists, "Project", "Project");
            return View(taskList);
        }

        // POST: TaskLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Task_ID,Parent_ID,Project_ID,Task,Start_Date,End_Date,Priority,Status")] TaskList taskList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Parent_ID = new SelectList(db.ParentTasks, "Parent_ID", "Parent_ID");
            ViewBag.Project_ID = new SelectList(db.ProjectLists, "Project_ID", "Project_ID");
            ViewBag.Parent_Task = new SelectList(db.ParentTasks, "Parent_Task", "Parent_Task");
            ViewBag.Project = new SelectList(db.ProjectLists, "Project", "Project");
            return View(taskList);
        }

        // GET: TaskLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList taskList = db.TaskLists.Find(id);
            if (taskList == null)
            {
                return HttpNotFound();
            }
            return View(taskList);
        }

        // POST: TaskLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskList taskList = db.TaskLists.Find(id);
            db.TaskLists.Remove(taskList);
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
