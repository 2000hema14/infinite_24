using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Web.Helpers;
using EMS.Models;

namespace EMS.Controllers
{

    [Authorize]
    public class EmployeesController : Controller
    {
        private EmpDatabaseEntities3 db = new EmpDatabaseEntities3();

        // GET: Employees
        public ActionResult Index(int page = 1, string sort = "Emp_First_Name", string sortdir = "asc", string search = "")
        {
            int pageSize = 5;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = GetEmployees(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;

            if (TempData["AlertMessage"] != null)
            {
                ViewBag.AlertMessage = TempData["AlertMessage"];
            }

            return View(data);
        }

        public List<Employee> GetEmployees(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            var v = (from a in db.Employees
                     where
                             a.Emp_First_Name.Contains(search) ||
                             a.Emp_Last_Name.Contains(search) ||
                             a.Emp_Home_Address.Contains(search) ||
                             a.Emp_Grade.Contains(search) ||
                             a.Emp_Designation.Contains(search)
                     select a
                    );
            totalRecord = v.Count();
            v = v.OrderBy(sort + " " + sortdir);
            if (pageSize > 0)
            {
                v = v.Skip(skip).Take(pageSize);
            }
            return v.ToList();
        }


        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Emp_Dept_ID = new SelectList(db.Departments, "Dept_ID", "Dept_Name");
            ViewBag.Emp_Grade = new SelectList(db.Grade_master, "Grade_Code", "Grade_Code");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Emp_ID,Emp_First_Name,Emp_Last_Name,Emp_Date_of_Birth,Emp_Date_of_Joining,Emp_Dept_ID,Emp_Grade,Emp_Designation,Emp_Salary,Emp_Gender,Emp_Marital_Status,Emp_Home_Address,Emp_Contact_Num")] Employee employee)
        {
            if (db.Employees.Any(d => d.Emp_ID == employee.Emp_ID))
            {
                ModelState.AddModelError("Emp_ID", "Employee ID already exists.");
            }

            var grade = db.Grade_master.FirstOrDefault(g => g.Grade_Code == employee.Emp_Grade);
            if (grade != null)
            {
                if (employee.Emp_Salary < grade.Min_Salary || employee.Emp_Salary > grade.Max_Salary)
                {
                    ModelState.AddModelError("Emp_Salary", $"Salary must be between {grade.Min_Salary} and {grade.Max_Salary} for grade {grade.Grade_Code}");
                }
            }
            else
            {
                ModelState.AddModelError("Emp_Grade", "Invalid Grade");
            }

            if (string.IsNullOrEmpty(employee.Emp_Contact_Num) || employee.Emp_Contact_Num.Length != 10)
            {
                ModelState.AddModelError("Emp_Contact_Num", "Contact Number must be 10 digits");
            }

            if (ModelState.IsValid)
            {
                // Set the status to "Active" by default
                employee.Status = "Active";

                db.Employees.Add(employee);
                db.SaveChanges();
                TempData["AlertMessage"] = "Employee Added Successfully....!";
                return RedirectToAction("Index");
            }

            ViewBag.Emp_Dept_ID = new SelectList(db.Departments, "Dept_ID", "Dept_Name", employee.Emp_Dept_ID);
            ViewBag.Emp_Grade = new SelectList(db.Grade_master, "Grade_Code", "Description", employee.Emp_Grade);
            return View(employee);
        }


        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Emp_Dept_ID = new SelectList(db.Departments, "Dept_ID", "Dept_Name", employee.Emp_Dept_ID);
            ViewBag.Emp_Grade = new SelectList(db.Grade_master, "Grade_Code", "Grade_Code", employee.Emp_Grade);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Emp_ID,Emp_First_Name,Emp_Last_Name,Emp_Date_of_Birth,Emp_Date_of_Joining,Emp_Dept_ID,Emp_Grade,Emp_Designation,Emp_Salary,Emp_Gender,Emp_Marital_Status,Emp_Home_Address,Emp_Contact_Num,Status")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var grade = db.Grade_master.FirstOrDefault(g => g.Grade_Code == employee.Emp_Grade);
                if (grade != null)
                {
                    if (employee.Emp_Salary < grade.Min_Salary || employee.Emp_Salary > grade.Max_Salary)
                    {
                        ModelState.AddModelError("Emp_Salary", $"Salary must be between {grade.Min_Salary} and {grade.Max_Salary} for the selected grade.");
                        ViewBag.Emp_Dept_ID = new SelectList(db.Departments, "Dept_ID", "Dept_Name", employee.Emp_Dept_ID);
                        ViewBag.Emp_Grade = new SelectList(db.Grade_master, "Grade_Code", "Description", employee.Emp_Grade);
                        return View(employee);
                    }
                }

                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Employee Updated Successfully....!";
                return RedirectToAction("Index");
            }
            ViewBag.Emp_Dept_ID = new SelectList(db.Departments, "Dept_ID", "Dept_Name", employee.Emp_Dept_ID);
            ViewBag.Emp_Grade = new SelectList(db.Grade_master, "Grade_Code", "Description", employee.Emp_Grade);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null)
            {
                if (employee.Status == "Active")
                {
                    employee.Status = "Inactive";
                    db.SaveChanges();
                    TempData["AlertMessage"] = "Employee status has been changed to inactive successfully.";
                }
                else if (employee.Status == "Inactive")
                {
                    TempData["AlertMessage"] = "Employee is already inactive.";
                }
            }
            else
            {
                TempData["AlertMessage"] = "Employee not found.";
            }
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