using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MvcRoute.BLL.Interfaces;
using MvcRoute.DAL.Models;
using System;

namespace MvcRoute.PL.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment _env; 
        public DepartmentsController(IUnitOfWork unitOfWork ,IWebHostEnvironment env)
        {
            this.unitOfWork = unitOfWork;
            _env = env;
        }   

        public IActionResult Index()
        {
            
            return View(unitOfWork.DepartmentRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }    
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) { 
            var count  =  unitOfWork.DepartmentRepository.Add(department);
                if (count > 0)
                {
                    TempData["Message"] = "Department Created Successfully"; 
                    return RedirectToAction("Index");
                }
            }
        
            return View();

        }

        public IActionResult Details(int? id , string viewName = "Details") { 
        
            if (!id.HasValue) return BadRequest();
            var department = unitOfWork.DepartmentRepository.Get(id.Value);
            if (department == null) return NotFound();
            return View(viewName,department); 
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id,"Edit");
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
     
            if (ModelState.IsValid) {
                try
                {
                    unitOfWork.DepartmentRepository.Update(department);
                    return RedirectToAction("Index");
                }
                catch (Exception ex) {

                    if (_env.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                    else {
                        ModelState.AddModelError(string.Empty, "An Error has occuredd during the process");
                    }

                
                }

            }
            return View(department);

        }
        [HttpGet]
        public IActionResult Delete(int? id) {

            return Details(id, "Delete");
        }   
        [HttpPost]
        public IActionResult Delete(Department department) {

            try
            {
                unitOfWork.DepartmentRepository.Delete(department);
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

            return View(department);
        }
    }
}
