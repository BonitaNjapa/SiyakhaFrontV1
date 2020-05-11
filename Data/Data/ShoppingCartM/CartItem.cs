using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ShoppingCartM
{
    public class CartItem
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("Cart")]
        public string cartId { get; set; }
        [ForeignKey("Item")]
        public int ItemdId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public int? OrderId { get; set; }
        public string UserEmail { get; set; }
        public virtual Item Item { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
