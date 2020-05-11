using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CartService
{
    public interface ICart : IDisposable
    {
        Cart GetById(Int32 id);
        IEnumerable<Cart> GetAll();
        void Insert(Cart model);
        void Update(Cart model);
        void Delete(Cart model);
        IEnumerable<Cart> Find(Func<Cart, bool> predicate);
    }
}
