using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCut.BLL.Entities;
using HairCut.Services.Interfaces;
using HairCut.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCut.Web.Controllers
{
    [Authorize(Roles = "Employee")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            IEnumerable<AppointmentVm> appointmentVm = _appointmentService.GetAppointments();
            if (HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest")
                return PartialView(appointmentVm);
            else
                return View(appointmentVm);
        }

        public IActionResult AddAppointment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAppointment(AppointmentVm appointmentVm)
        {
            if (ModelState.IsValid)
            {
                _appointmentService.AddOrUpdateAppointment(appointmentVm);
                return RedirectToAction("Index");
            }
            else
                return View(ModelState);
        }

        public IActionResult EditAppointment(int id)
        {
            AppointmentVm appointmentVm = _appointmentService.GetAppointment(x => x.Id == id);
            return View(appointmentVm);
        }

        [HttpPost]
        public IActionResult EditAppointment(AppointmentVm appointmentVm)
        {
            if (ModelState.IsValid)
            {
                _appointmentService.AddOrUpdateAppointment(appointmentVm);
                return RedirectToAction("Index");
            }
            else
                return View(ModelState);
        }
    }
}