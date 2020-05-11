using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderDetailConFirm
    {
        public Data.ShoppingCartM.Order order { get; set; }
        public Data.ShoppingCartM.OrderAddress address { get; set; }
        public List<Data.ShoppingCartM.OrderItem> items { get; set; }
     
    }
}
