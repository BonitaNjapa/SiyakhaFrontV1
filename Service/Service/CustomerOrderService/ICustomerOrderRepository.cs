using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerOrderService
{
   public interface ICustomerOrderRepository : IDisposable
    {
        CustomerOrder GetById(Int32 id);
        IEnumerable<CustomerOrder> GetAll();
        void Insert(CustomerOrder model);
        void Update(CustomerOrder model);
        void Delete(CustomerOrder model);
        IEnumerable<CustomerOrder> Find(Func<CustomerOrder, bool> predicate);
    }
}
