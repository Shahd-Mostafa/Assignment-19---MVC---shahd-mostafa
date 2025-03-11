using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department? GetById(int id);
        void Delete(Department department);
        void Add(Department department);
        void Update(Department department);
    }
}
