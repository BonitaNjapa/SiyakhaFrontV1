using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CompSuppManager
{
   public class Supplier
    {
        [Key]
        public int Id  { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<ShoppingCartM.Item> Items { get; set; }
    }
}
