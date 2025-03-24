using Demo.DAL.Entities;

namespace Assignment_19___MVC___shahd_mostafa.Models
{
    public class EmployeeViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; }
        public bool isActive { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
