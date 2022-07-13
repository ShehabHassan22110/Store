using Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Interface
{
  public  interface ICommentRep
    {
        IEnumerable<Comment> Get();
        Comment GetById(int id);

        void Create(Comment obj);
        void Edit(Comment obj);
        void Delete(Comment obj);
    }
}
