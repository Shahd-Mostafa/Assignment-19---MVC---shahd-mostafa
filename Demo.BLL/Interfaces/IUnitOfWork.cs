using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
    }
}
