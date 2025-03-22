using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Create(TEntity entity);
    }
}
