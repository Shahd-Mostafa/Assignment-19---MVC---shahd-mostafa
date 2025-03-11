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
        public List<Department> GetAll() => _context.departments.ToList();
        public Department? GetById(int id) => _context.departments.Find(id);

        public void Delete(Department department)
        {
            _context.departments.Remove(department);
            _context.SaveChanges();
        }

        public void Add(Department department)
        {
            _context.departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            _context.departments.Update(department);
            _context.SaveChanges();
        }
    }
}
