using Demo.DAL.Context;
using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class DepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        //[FromServices]
        //public AppDbContext _context {  get; set; } 
        public List<Department> GetAll()
        {
            using var context = new AppDbContext();
            var departments = _context.departments.ToList();
            return departments;
        }
    }
}
