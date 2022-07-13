using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entity;
using Store.DAL.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Database
{
   public class StoreContext:IdentityDbContext<ApplicationUser,IdentityRole,string>
    {

        public StoreContext(DbContextOptions<StoreContext> opt) : base(opt)
        {

        }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Comment> Comment { get; set; }

    }
}
