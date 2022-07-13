using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.ViewModels
{
   public class CommentVM
    {
        public int Id { get; set; }

        public String Name { get; set; }
        [StringLength(50)]
        public string UserComment { get; set; }
    }
}
