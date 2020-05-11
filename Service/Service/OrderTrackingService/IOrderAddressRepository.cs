using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderTrackingService
{
    public interface IOrderAddressRepository : IDisposable
    {
        OrderAddress GetById(Int32 id);
        IEnumerable<OrderAddress> GetAll();
        void Insert(OrderAddress model);
        void Update(OrderAddress model);
        void Delete(OrderAddress model);
        IEnumerable<OrderAddress> Find(Func<OrderAddress, bool> predicate);
    }
}
