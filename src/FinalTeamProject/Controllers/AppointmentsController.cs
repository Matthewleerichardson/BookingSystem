using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalTeamProject.Data;
using FinalTeamProject.Models;

namespace FinalTeamProject.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly BookingContext _context;

        public AppointmentsController(BookingContext context)
        {
            _context = context;    
        }

        // GET: Appointments

        //public async Task<IActionResult> Index()
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var appointments = from s in _context.Appointments.Include(a => a.Customer).Include(a => a.Staff)

            select s;
            switch (sortOrder)
            {
                
                case "Date":
                    appointments = appointments.OrderBy(s => s.AppointmentDate);
                    break;
                case "date_desc":
                    appointments = appointments.OrderByDescending(s => s.AppointmentDate);
                    break;
                default:
                    appointments = appointments.OrderBy(s => s.AppointmentDate);
                    break;
            }
            return View(await appointments.AsNoTracking().ToListAsync());
        }
        //{
          //var bookingContext = _context.Appointments.Include(a => a.Customer).Include(a => a.Staff);
        //return View(await bookingContext.ToListAsync());
        //}

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
            .Include(a => a.Customer)
            .Include(a => a.Staff)
            .AsNoTracking()
            .SingleOrDefaultAsync(m => m.AppointmentID == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "LastName");
            ViewData["StaffID"] = new SelectList(_context.Staffs, "ID", "LastName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create
            ([Bind("AppointmentID,AppointmentDate,CustomerID,StaffID")] Appointment appointment)
        {
            try
            {
                if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

           // ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "LastName", appointment.CustomerID);
           // ViewData["StaffID"] = new SelectList(_context.Staffs, "ID", "LastName", appointment.StaffID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.SingleOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "LastName", appointment.CustomerID);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "ID", "LastName", appointment.StaffID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var appointmentToUpdate = await _context.Appointments.SingleOrDefaultAsync(s => s.AppointmentID == id);
            if (await TryUpdateModelAsync<Appointment>(
                appointmentToUpdate,
                "",
                s => s.AppointmentID, s => s.AppointmentDate, s => s.CustomerID, s => s.StaffID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(appointmentToUpdate);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.SingleOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.SingleOrDefaultAsync(m => m.AppointmentID == id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentID == id);
        }
    }
}
