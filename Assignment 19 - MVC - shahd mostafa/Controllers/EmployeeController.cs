using Assignment_19___MVC___shahd_mostafa.Helper;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private IActionResult controllerHandler(int id, string viewName)
        {
            var model = _unitOfWork.Employee.GetById(id);
            var employee = _mapper.Map<EmployeeViewModels>(model);
            return View(viewName, employee);
        }
        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index(string searchValue)
        {
            var Employees = new List<Employee>();
            if(searchValue!=null)
            {
                Employees = _unitOfWork.Employee.GetEmployeesBySearchValue(searchValue);
            }
            else Employees = _unitOfWork.Employee.GetAllWithDepartment();
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
            if (employee != null && employeeVm.Image.Length > 0)
            {
                employee.ImageName = DocumentSettings.UploadFile(employeeVm.Image, "Images");
            }
            _unitOfWork.Employee.Create(employee);
            var result = _unitOfWork.SaveChanges();
            if (result>0)
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
            if(employee !=null && employeeVm.Image.Length >0)
            {
                if(employee.ImageName!=null)
                {
                    DocumentSettings.DeleteFile(employeeVm.Image,"Images");
                }
                employee.ImageName = employeeVm.Image.UploadFile("Images");
            }
            _unitOfWork.Employee.Update(employee);
            var result = _unitOfWork.SaveChanges();
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
            if (employee.ImageName != null)
            {
                DocumentSettings.DeleteFile(employeeVm.Image, "Images");
            }
            _unitOfWork.Employee.Delete(employee);
            var result = _unitOfWork.SaveChanges();
            if (result > 0) return RedirectToAction("Index");
            return View(employeeVm);
        }

        private void AddDepartmentViewBag()
        {
            var department = _unitOfWork.Department.GetAll();
            SelectList listItems = new SelectList(department, nameof(Department.Id), nameof(Department.Name));
            ViewBag.Departments = listItems;
        }

    }
}
