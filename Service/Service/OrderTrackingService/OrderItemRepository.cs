using Data;
using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderTrackingService
{
    public class OrderItemRepository
    {
        private DataContext _dataContext = null;
        private readonly IRepository<OrderItem> _OrderItemRepository;


        public OrderItemRepository()
        {
            _dataContext = new DataContext();
            _OrderItemRepository = new RepositoryService<OrderItem>(_dataContext);

        }

        public void Delete(OrderItem model)
        {
            _OrderItemRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<OrderItem> Find(Func<OrderItem, bool> predicate)
        {
            return _OrderItemRepository.Find(predicate);
        }

        public List<OrderItem> GetAll()
        {
            return _OrderItemRepository.GetAll().ToList();
        }

        public OrderItem GetById(int id)
        {
            return _OrderItemRepository.GetById(id);
        }

        public void Insert(OrderItem model)
        {
            _OrderItemRepository.Insert(model);
        }

        public void Update(OrderItem model)
        {
            _OrderItemRepository.Update(model);
        }

        public OrderItem GetById(string custId)
        {
            return _OrderItemRepository.GetById(custId);
        }
    }
}
