using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ItemService
{
    public interface IItemRepository : IDisposable
    {
        Item GetById(Int32 id);
        IEnumerable<Item> GetAll();
        void Insert(Item model);
        void Update(Item model);
        void Delete(Item model);
        IEnumerable<Item> Find(Func<Item, bool> predicate);
    }
}
