using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entity
{
   public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string Description { get; set; }
        public String Brand { get; set; }
        public int Model { get; set; }
        public int Salary { get; set; }
        public String Offer { get; set; }
        public string PhotoName { get; set; }
        public string CvName { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public double Vat { get; set; }
        public double Total { get; set; }
    }
}
