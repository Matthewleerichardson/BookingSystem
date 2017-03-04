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
    public class StaffsController : Controller
    {
        private readonly BookingContext _context;

        public StaffsController(BookingContext context)
        {
            _context = context;    
        }

        // GET: Staffs
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var staffs = from s in _context.Staffs
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                staffs = staffs.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    staffs = staffs.OrderByDescending(s => s.LastName);
                    staffs = staffs.OrderByDescending(s => s.FirstName);
                    break;
                default:
                    staffs = staffs.OrderBy(s => s.LastName);
                    staffs = staffs.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Staff>.CreateAsync(staffs.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .Include(c => c.Appointment)
                .ThenInclude(e => e.Customer)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (staff == null)
            
                {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Telephone")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs.SingleOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Telephone")] Staff staff)
        {
            if (id != staff.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs.SingleOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staffs.SingleOrDefaultAsync(m => m.ID == id);
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.ID == id);
        }
    }
}
