using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stomatology.Data;

namespace Stomatology.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        
        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Management()
        {
            var services = context.Services.ToList();
            return View(services);
        }

        public IActionResult ManagementofTheUsers()
        {
            var appointments = context.Appointments.Include(u=>u.User).ToList();
            return View(appointments);
        }

        public IActionResult DeleteAppointment(int id)
        {
            var appointment = context.Appointments.Where(a => a.Id == id).FirstOrDefault();
            context.Remove(appointment);
            context.SaveChanges();
            return RedirectToAction("ManagementofTheUsers");
        }

        public IActionResult EditAppointment(int id)
        {
            var appointment = context.Appointments.Where(a => a.Id == id).FirstOrDefault();
          
            return View(appointment);
        }

        [HttpPost]
        public IActionResult EditAppointment(int id, Appointment newAppointment)
        {
            var appointment = context.Appointments.Where(a => a.Id == id).FirstOrDefault();
            context.Entry(appointment).CurrentValues.SetValues(newAppointment);
            context.SaveChanges();
            return RedirectToAction("ManagementofTheUsers");
        }

        public IActionResult Delete(int id)
        {
            var service = context.Services.Where(s=>s.Id==id).FirstOrDefault();
            context.Remove(service);
            context.SaveChanges();
            return RedirectToAction("Management");
        }

        public IActionResult Create()
        {      
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            context.Add(service);
            context.SaveChanges();
            return RedirectToAction("Management");
        }

        public IActionResult Edit(int id)
        {
            var service = context.Services.Where(s => s.Id == id).FirstOrDefault();

            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(int id, Service newService)
        {
            var service = context.Services.Where(s => s.Id == id).FirstOrDefault();
            context.Entry(service).CurrentValues.SetValues(newService);
            context.SaveChanges();
            return RedirectToAction("Management");
        }
    }
}