using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderTrackingService
{
    interface IOrderTracking
    {
        OrderTracking GetById(Int32 id);
        IEnumerable<OrderTracking> GetAll();
        void Insert(OrderTracking model);
        void Update(OrderTracking model);
        void Delete(OrderTracking model);
        IEnumerable<OrderTracking> Find(Func<OrderTracking, bool> predicate);
    }
}
