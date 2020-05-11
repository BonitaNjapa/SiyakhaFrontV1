using Data;
using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderService
{
   public class OrderRepository
    {

        private DataContext _dataContext = null;
        private readonly IRepository<Order> _OrderRepository;


        public OrderRepository()
        {
            _dataContext = new DataContext();
            _OrderRepository = new RepositoryService<Order>(_dataContext);

        }

        public void Delete(Order model)
        {
            _OrderRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return _OrderRepository.Find(predicate);
        }

        public List<Order> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public Order GetById(int id)
        {
            return _OrderRepository.GetById(id);
        }

        public void Insert(Order model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(Order model)
        {
            _OrderRepository.Update(model);
        }

        public Order GetById(string custId)
        {
            return _OrderRepository.GetById(custId);
        }

        
    }
}
