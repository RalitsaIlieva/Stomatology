using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stomatology.Data;
using Stomatology.Models;

namespace Stomatology.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly AppointmentViewModel appointmentViewModel;
        private readonly IMapper mapper;

        public HomeController(ApplicationDbContext context, AppointmentViewModel appointmentViewModel, IMapper mapper)
        {
            this.context = context;
            this.appointmentViewModel = appointmentViewModel;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Price()
        {
            var services = context.Services.ToList();
            return View(services);
        }

        public IActionResult Appointment()
        {
            //List<SelectListItem> allHours = new List<SelectListItem>
            //{
            //    new SelectListItem { Value = "9:00:00 AM", Text = "9:00:00 AM" },
            //new SelectListItem {Value = "9:30:00 AM", Text = "9:30:00 AM" },
            //new SelectListItem {Value = "10:00:00 AM", Text = "10:00:00 AM" },
            //new SelectListItem {Value = "10:30:00 AM", Text = "10:30:00 AM" },
            //new SelectListItem {Value = "5:30:00 AM", Text = "5:30:00 AM" }
            //};
            //var hours = context.Appointments.Select(a => a.Hour).ToList();
            ////foreach (var item in hours)
            ////{
            ////    var itemArr = item.ToString().Split(' ');
            ////    var item2 = itemArr[1];
            ////    var item3 = itemArr[2];
            ////    var result = item2 + " " + item3;
            ////    allHours.Remove(result);
            ////}
            //appointmentViewModel.HoursAvailable = allHours;
            return View();
        }

        [HttpPost]
        public IActionResult Appointment(AppointmentViewModel appointment)
        {
            string[] appointmentDate = appointment.Date.ToString().Split(" ");
            string[] firstPartOfTheAppointmentDate = appointmentDate[0].Split("/");
            string dateForComparison = firstPartOfTheAppointmentDate[2] + "-" + firstPartOfTheAppointmentDate[0] + "-" + firstPartOfTheAppointmentDate[1]+" "+"00:00:00.0000000";
            if (ModelState.IsValid && (context.Appointments.Any(u => u.Date.ToString() == dateForComparison) == false
                && context.Appointments.Any(u => u.Hour== appointment.Hour) == false)||
                (context.Appointments.Any(u => u.Date.ToString() == dateForComparison) == true
                && context.Appointments.Any(u => u.Hour == appointment.Hour) == false))
            {
                var newAppointment = mapper.Map<Appointment>(appointment);
                context.Add(newAppointment);
                context.SaveChanges();
                return RedirectToAction("AppointmentDone");
            }
            if (ModelState.IsValid && context.Appointments.Any(u => u.Date.ToString() == dateForComparison) == true
                 && context.Appointments.Any(u => u.Hour == appointment.Hour) == true)
            {
                return Content("Опитайте друг час. Този е зает!!!");
            }
            else {
                return View();
            }
          //  return RedirectToAction("SameEGN");
     
        }

        public IActionResult AppointmentDone()
        {
            return View();
        }

        //public IActionResult SameEGN()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
