using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderTrackingService
{
    interface IOrderDetailsRepository : IDisposable
    {
        OrderDetails GetById(Int32 id);
        IEnumerable<OrderDetails> GetAll();
        void Insert(OrderDetails model);
        void Update(OrderDetails model);
        void Delete(OrderDetails model);
        IEnumerable<OrderDetails> Find(Func<OrderDetails, bool> predicate);
    }
}
