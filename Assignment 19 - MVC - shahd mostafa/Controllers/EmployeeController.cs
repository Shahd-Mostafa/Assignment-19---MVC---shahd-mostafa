using Assignment_19___MVC___shahd_mostafa.Models;
using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_19___MVC___shahd_mostafa.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly IDepartmentRepository _department;
        private readonly IMapper _mapper;

        private IActionResult controllerHandler(int id, string viewName)
        {
            var model = _repository.GetById(id);
            var employee = _mapper.Map<EmployeeViewModels>(model);
            return View(viewName, employee);
        }
        public EmployeeController(IEmployeeRepository repository,IDepartmentRepository department,IMapper mapper)
        {
            _repository = repository;
            _department = department;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var Employees = _repository.GetAllWithDepartment();
            //var employeesViewModel = Employees.Select(e => new EmployeeViewModels
            //{
            //    Address = e.Address,
            //    Age = e.Age,
            //    DepartmentId= e.DepartmentId,
            //    Department=e.Department,
            //    Name=e.Name,
            //    Email=e.Email,
            //    Id=e.Id,
            //    isActive=e.isActive,
            //    Phone=e.Phone,
            //    Salary=e.Salary,
            //}
            //);
            var employeesViewModel = _mapper.Map<List<EmployeeViewModels>>(Employees);
            return View(employeesViewModel);
        }

        public IActionResult Create()
        {
            AddDepartmentViewBag();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModels employeeVm)
        {
            if (!ModelState.IsValid)
            {
                AddDepartmentViewBag();
                return View(employeeVm);
            }
            var employee = _mapper.Map<Employee>(employeeVm);
            var result=_repository.Create(employee);
            if(result>0)
            {
                TempData["Message"] = "Employee Created Successfully!";
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id,EmployeeViewModels employeeVm)
        {
            if(id!= employeeVm.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                AddDepartmentViewBag();
                return View(employeeVm);
            }
            var employee = _mapper.Map<Employee>(employeeVm);
            var result = _repository.Update(employee);
            if (result > 0) return RedirectToAction("Index");
            return View(employeeVm);
        }

        public IActionResult Edit(int id)
        {
            AddDepartmentViewBag();
            return controllerHandler(id, nameof(Edit));
        }

        public IActionResult Delete(int id)
        {
            AddDepartmentViewBag();
            return controllerHandler(id, nameof(Delete));
        }
        public IActionResult Details(int id)
        {
                AddDepartmentViewBag();
                return controllerHandler(id, nameof(Details));
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, EmployeeViewModels employeeVm)
        {
            if (id != employeeVm.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(employeeVm);
            }
            var employee = _mapper.Map<Employee>(employeeVm);
            var result = _repository.Delete(employee);
            if (result > 0) return RedirectToAction("Index");
            return View(employeeVm);
        }

        private void AddDepartmentViewBag()
        {
            var department = _department.GetAll();
            SelectList listItems = new SelectList(department, nameof(Department.Id), nameof(Department.Name));
            ViewBag.Departments = listItems;
        }

    }
}
