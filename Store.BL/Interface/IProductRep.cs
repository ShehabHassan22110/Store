using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Interface
{
   public interface IProductRep
    {
        IEnumerable<Product> Get();
        Product GetById(int id);

        void Create(Product obj);
        void Edit(Product obj);
        void Delete(Product obj);
    }
}
