using Data;
using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CartService
{
    public class CartItemRepository : CartItemService.ICartItemItemRepository
    {

        private DataContext _dataContext = null;
        private readonly IRepository<CartItem> _cartItemRepository;


        public CartItemRepository()
        {
            _dataContext = new DataContext();
            _cartItemRepository = new RepositoryService<CartItem>(_dataContext);

        }

        public void Delete(CartItem model)
        {
            _cartItemRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<CartItem> Find(Func<CartItem, bool> predicate)
        {
            return _cartItemRepository.Find(predicate);
        }

        public IEnumerable<CartItem> GetAll()
        {
            return _cartItemRepository.GetAll().ToList();
        }

        public CartItem GetById(int id)
        {
            return _cartItemRepository.GetById(id);
        }

        public void Insert(CartItem model)
        {
            _cartItemRepository.Insert(model);
        }

        public void Update(CartItem model)
        {
            _cartItemRepository.Update(model);
        }

        public CartItem GetById(string custId)
        {
            return _cartItemRepository.GetById(custId);
        }

        public void DeleteRange(IEnumerable<CartItem> cartItems)
        {
            _cartItemRepository.DeleteRange(cartItems);
        }
    }
}
