using Demo.BLL.Interfaces;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_19___MVC___shahd_mostafa.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        private IActionResult controllerHandler(int id, string viewName)
        {
            var model = _repository.GetById(id);
            return View(viewName, model);
        }
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var Employees = _repository.GetAll();
            return View(Employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            var result=_repository.Create(employee);
            if(result>0)
            {
                TempData["Message"] = "Employee Created Successfully!";
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id,Employee employee)
        {
            if(id!=employee.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            var result = _repository.Update(employee);
            if (result > 0) return RedirectToAction("Index");
            return View(result);
        }

        public IActionResult Edit(int id) =>controllerHandler(id,nameof(Edit));
        public IActionResult Delete(int id) => controllerHandler(id, nameof(Delete));
        public IActionResult Details(int id) => controllerHandler(id, nameof(Details));

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            var result = _repository.Delete(employee);
            if (result > 0) return RedirectToAction("Index");
            return View(result);
        }

    }
}
