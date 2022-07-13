using Store.BL.ViewModels;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Interface
{
   public interface IEmployeeRep
    {
        IEnumerable<Employee> Get();
        Employee GetById(int id);

        void Create(Employee obj);
        void Edit(Employee obj);
        void Delete(Employee obj);

    }
}
