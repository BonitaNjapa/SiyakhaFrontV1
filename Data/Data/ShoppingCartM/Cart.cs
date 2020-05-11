using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Cart
    {
        [Key]
        public string CartID { get; set; }
        public DateTime date_created { get; set; }
        public string userId { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
