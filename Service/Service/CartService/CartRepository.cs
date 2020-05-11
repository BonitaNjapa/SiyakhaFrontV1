using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CartService
{
    public class CartRepository : ICart
    {

        private DataContext _dataContext = null;
        private readonly IRepository<Cart> _cartRepository;


        public CartRepository()
        {
            _dataContext = new DataContext();
            _cartRepository = new RepositoryService<Cart>(_dataContext);

        }

        public void Delete(Cart model)
        {
            _cartRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<Cart> Find(Func<Cart, bool> predicate)
        {
            return _cartRepository.Find(predicate).ToList();
        }

        public IEnumerable<Cart> GetAll()
        {
            return _cartRepository.GetAll().ToList();
        }

        public Cart GetById(int id)
        {
            return _cartRepository.GetById(id);
        }

        public void Insert(Cart model)
        {
            _cartRepository.Insert(model);
        }

        public void Update(Cart model)
        {
            _cartRepository.Update(model);
        }

        public Cart GetById(string custId)
        {
            return _cartRepository.GetById(custId);
        }
    }
}
