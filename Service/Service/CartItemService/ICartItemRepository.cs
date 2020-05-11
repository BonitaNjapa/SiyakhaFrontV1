using Data;
using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CartItemService
{
    public interface ICartItemItemRepository
    {
        CartItem GetById(Int32 id);
        IEnumerable<CartItem> GetAll();
        void Insert(CartItem model);
        void Update(CartItem model);
        void Delete(CartItem model);
        void DeleteRange(IEnumerable<CartItem> cartItems);
        IEnumerable<CartItem> Find(Func<CartItem, bool> predicate);
    }
}
