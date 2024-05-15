using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using EMS.Models;

namespace EMS.Controllers
{
    public class EmpTimesheetController : Controller
    {
        private readonly EmpDatabaseEntities3 _context;

        public EmpTimesheetController()
        {
            _context = new EmpDatabaseEntities3();
        }

        // GET: EmpTimesheet
        public async Task<ActionResult> Index()
        {
            var timesheets = await _context.Emp_Timesheet.Include(t => t.Employee).ToListAsync();
            return View(timesheets);
        }

        // GET: EmpTimesheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpTimesheet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Emp_ID,WeekStartingDate,HoursWorked,Status")] Emp_Timesheet emp_Timesheet)
        {
            if (ModelState.IsValid)
            {
                _context.Emp_Timesheet.Add(emp_Timesheet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(emp_Timesheet);
        }

        // GET: EmpTimesheet/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Emp_Timesheet emp_Timesheet = await _context.Emp_Timesheet.FindAsync(id);
            if (emp_Timesheet == null)
            {
                return HttpNotFound();
            }

            return View(emp_Timesheet);
        }

        // POST: EmpTimesheet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Timesheet_ID,Emp_ID,WeekStartingDate,HoursWorked,Status")] Emp_Timesheet emp_Timesheet)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(emp_Timesheet).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(emp_Timesheet);
        }

        // GET: EmpTimesheet/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Emp_Timesheet emp_Timesheet = await _context.Emp_Timesheet.FindAsync(id);
            if (emp_Timesheet == null)
            {
                return HttpNotFound();
            }

            return View(emp_Timesheet);
        }
    }
}
