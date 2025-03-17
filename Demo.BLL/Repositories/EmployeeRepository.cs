using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository :GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) :base(context)
        {
            _context = context;
            
        }

        public List<Employee> GetAllWithDepartment() =>_context.Employees.Include(c=>c.Department).ToList();

        public List<Employee> GetEmployeesBySearchValue(string searchValue)
        {
            throw new NotImplementedException();
        }
    }
}
