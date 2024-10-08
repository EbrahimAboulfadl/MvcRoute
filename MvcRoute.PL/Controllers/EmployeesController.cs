﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MvcRoute.BLL.Helper;
using MvcRoute.BLL.Interfaces;
using MvcRoute.DAL.Models;
using MvcRoute.PL.Models;
using System;
using System.IO;

namespace MvcRoute.PL.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper mapper;

        public EmployeesController(IUnitOfWork unitOfWork, IWebHostEnvironment env , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _env = env;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {

            return View(unitOfWork.EmployeeRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {

            var mappedEmployee = mapper.Map<EmployeeViewModel,Employee>(employeeVM);
            if (employeeVM.Image != null) {
                mappedEmployee.Image =
                FileHandler.UploadFile(employeeVM.Image, "images");
            }

            if (ModelState.IsValid)
            { 

                var count = unitOfWork.EmployeeRepository.Add(mappedEmployee);
                if (count > 0)
                {

                    TempData["Message"] = "Employee Added Successfully";

                    return RedirectToAction("Index");
                }
            }

            return View(employeeVM);

        }

        public IActionResult Details(int? id, string viewName = "Details")
        {

            if (!id.HasValue) return BadRequest();
            var employee = unitOfWork.EmployeeRepository.Get(id.Value);
            if (employee == null) return NotFound();
            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll();
            return View(viewName, employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll();

            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.EmployeeRepository.Update(employee);
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
                unitOfWork.EmployeeRepository.Delete(employee,directoryPath:Directory.GetCurrentDirectory());
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
