
using Store.BL.Interface;
using Store.BL.ViewModels;
using Store.DAL.Database;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Repository
{
   public class EmployeeRep:IEmployeeRep
    {

      
        private readonly StoreContext db;
        public EmployeeRep(StoreContext db)
        {
            this.db = db;
        }


        public IEnumerable<Employee> Get()
        {
            var data = GetDepartment();
            return data;
        }

        public Employee GetById(int id)
        {
            var data = db.Employee.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public void Create(Employee obj)
        {
            db.Employee.Add(obj);
            db.SaveChanges();
        }


        public void Edit(Employee obj)
        {

            var oldData = db.Employee.Find(obj.Id);

            oldData.Name = obj.Name;
            oldData.Code = obj.Code;

            db.SaveChanges();

        }


        public void Delete(Employee obj)
        {

            db.Employee.Remove(obj);
            db.SaveChanges();
        }






        // ============================= Refactor ============================
        private IEnumerable<Employee> GetDepartment()
        {
            return db.Employee.Select(a => a);
        }

    }
}
