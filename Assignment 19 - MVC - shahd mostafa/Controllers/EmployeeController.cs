using Demo.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_19___MVC___shahd_mostafa.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var Employees = _repository.GetAll();
            return View(Employees);
        }
    }
}
