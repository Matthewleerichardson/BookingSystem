using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalTeamProject.Data;
using FinalTeamProject.Models.BookigViewModels;

namespace FinalTeamProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookingContext _context;

        public HomeController(BookingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<CustomerGroup> data =
                from Appointment in _context.Appointments
                group Appointment by Appointment.AppointmentDate into dateGroup 
                select new CustomerGroup()
                {
                   AppointmentDate = dateGroup.Key,
                    CustomerCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
