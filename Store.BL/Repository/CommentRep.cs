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
    public class CommentRep : ICommentRep
    {
        private readonly StoreContext db;
        public CommentRep(StoreContext db)
        {
            this.db = db;
        }


        public IEnumerable<Comment> Get()
        {
            var data = GetComment();
            return data;
        }

        public Comment GetById(int id)
        {
            var data = db.Comment.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public void Create(Comment obj)
        {
            db.Comment.Add(obj);
            db.SaveChanges();
        }


        public void Edit(Comment obj)
        {

            var oldData = db.Comment.Find(obj.Id);

            oldData.Name = obj.Name;
            oldData.UserComment = obj.UserComment;

            db.SaveChanges();

        }


        public void Delete(Comment obj)
        {

            db.Comment.Remove(obj);
            db.SaveChanges();
        }






        // ============================= Refactor ============================
        private IEnumerable<Comment> GetComment()
        {
            return db.Comment.Select(a => a);

        }
    }
}
