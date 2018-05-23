using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCut.Services.Interfaces;
using HairCut.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCut.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult Index()
        {
            IEnumerable<EmployeeVm> employeeVm = _employeeService.GetEmployees();
            if (HttpContext.Request.Headers["x-requested-with"]=="XMLHttpRequest")
            {
                return PartialView(employeeVm);
            }
            return View(employeeVm);
        }

        //// GET: Employee/Create
        //public ActionResult CreateEmployee()
        //{
        //    return View(new EmployeeVm());
        //}

        //// POST: Employee/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateEmployee(AddOrUpdateEmployeeVm employeeVm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _employeeService.AddOrUpdateEmployee(employeeVm);
        //        return RedirectToAction("Index");
        //    }
        //    return View(ModelState);

        //}

        ////GET: Employee/Edit/5
        public ActionResult EditEmployee(int id)
        {
            AddOrUpdateEmployeeVm employeeVm = _employeeService.GetEmployee(y => y.Id ==id);
            return View(employeeVm );
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(AddOrUpdateEmployeeVm employeeVm)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddOrUpdateEmployee(employeeVm);
                return RedirectToAction("Index");
            }
            else
                return View(employeeVm);
            
        }

        // GET: Employee/Delete/5
        public ActionResult DeleteEmployee(int id)
        {
            var employeeVm = _employeeService.GetEmployee(y => y.Id == id);
            return View(employeeVm);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployee(AddOrUpdateEmployeeVm employeeVm)
        {
            _employeeService.DeleteEmployee(employeeVm.Id);
            return RedirectToAction("Index");

        }
    }
}