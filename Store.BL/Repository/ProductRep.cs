using Microsoft.EntityFrameworkCore;
using Store.BL.Interface;
using Store.DAL.Database;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Repository
{
   public class ProductRep : IProductRep
    {
        private readonly StoreContext st;
        public ProductRep(StoreContext st)
        {
            this.st = st;
        }

        public IEnumerable<Product> Get()
        {
            var data = st.Product.Select(a => a);
            return data;
        }

        public Product GetById(int id)
        {
            var data = st.Product.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
        public void Create(Product obj)
        {
            st.Product.Add(obj);
            st.SaveChanges();
        }

       

        public void Edit(Product obj)
        {
            st.Entry(obj).State = EntityState.Modified;
            st.SaveChanges();
        }
        public void Delete(Product obj)
        {
            st.Product.Remove(obj);
            st.SaveChanges();
        }


        // ============================= Refactor ============================
        //private IEnumerable<Product> GetProduct()
        //{
        //    return st.Product.Select(a => a);
        //}

    }
}
