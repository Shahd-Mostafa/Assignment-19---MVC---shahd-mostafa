using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        readonly Lazy<IDepartmentRepository> _departmentRepository;
        readonly Lazy<IEmployeeRepository> _employeeRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _departmentRepository=new (()=>new DepartmentRepository(context));
            _employeeRepository=new (() => new EmployeeRepository(context));
        }

        public IDepartmentRepository Department => _departmentRepository.Value;

        public IEmployeeRepository Employee =>_employeeRepository.Value;

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
