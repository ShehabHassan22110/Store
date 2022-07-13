using AutoMapper;
using Store.BL.ViewModels;
using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Mapper
{
  public  class DomainProfile :Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();

            CreateMap<Comment, CommentVM>();
            CreateMap<CommentVM, Comment>();
        }
    }
}
