using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderTrackingService
{
    interface IOrderItemRepository : IDisposable
    {
        OrderItem GetById(Int32 id);
        IEnumerable<OrderItem> GetAll();
        void Insert(OrderItem model);
        void Update(OrderItem model);
        void Delete(OrderItem model);
        IEnumerable<OrderItem> Find(Func<OrderItem, bool> predicate);
    }
}
