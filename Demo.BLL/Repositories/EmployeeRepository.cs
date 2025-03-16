using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository :GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) :base(context)
        {
            _context = context;
            
        }

        public List<Employee> GetEmployeesBySearchValue(string searchValue)
        {
            throw new NotImplementedException();
        }
    }
}
