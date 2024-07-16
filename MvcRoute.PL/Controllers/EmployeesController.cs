using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MvcRoute.BLL.Interfaces;
using MvcRoute.DAL.Models;
using System;

namespace MvcRoute.PL.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IWebHostEnvironment _env;
        public EmployeesController(IEntityRepository<Employee> employeeRepository, IWebHostEnvironment env)
        {
            _employeeRepository = employeeRepository;
            _env = env;
        }

        public IActionResult Index()
        {

            return View(_employeeRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var count = _employeeRepository.Add(employee);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();

        }

        public IActionResult Details(int? id, string viewName = "Details")
        {

            if (!id.HasValue) return BadRequest();
            var employee = _employeeRepository.Get(id.Value);
            if (employee == null) return NotFound();
            return View(viewName, employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Update(employee);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    if (_env.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "An Error has occuredd during the process");
                    }


                }

            }
            return View(employee);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {

            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {

            try
            {
                _employeeRepository.Delete(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An Error has occured during the process");
                }


            }

            return View(employee);
        }
    }
}
