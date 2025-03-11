using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
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

    }
}
