using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.ProductOrder
{
   public interface IProductOrderRepository : IDisposable
    {
        Data.ShoppingCartM.ProductOrder GetById(Int32 id);
        IEnumerable< Data.ShoppingCartM.ProductOrder> GetAll();
        void Insert( Data.ShoppingCartM.ProductOrder model);
        void Update( Data.ShoppingCartM.ProductOrder model);
        void Delete( Data.ShoppingCartM.ProductOrder model);
        IEnumerable< Data.ShoppingCartM.ProductOrder> Find(Func< Data.ShoppingCartM.ProductOrder, bool> predicate);
    }
}
