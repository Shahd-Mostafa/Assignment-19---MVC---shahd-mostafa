using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_19___MVC___shahd_mostafa.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _repository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _repository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department) {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            _repository.Add(department);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department= _repository.GetById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            _repository.Update(department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _repository.GetById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            _repository.Delete(department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var departments = _repository.GetById(id);
            return View(departments);
        }
    }
}
