using Data;
using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderTrackingService
{
    public class OrderTrackingRepository : IOrderTracking
    {
        private DataContext _dataContext = null;
        private readonly IRepository<OrderTracking> _OrderTrackingRepository;


        public OrderTrackingRepository()
        {
            _dataContext = new DataContext();
            _OrderTrackingRepository = new RepositoryService<OrderTracking>(_dataContext);

        }

        public void Delete(OrderTracking model)
        {
            _OrderTrackingRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<OrderTracking> Find(Func<OrderTracking, bool> predicate)
        {
            return _OrderTrackingRepository.Find(predicate);
        }

        public IEnumerable<OrderTracking> GetAll()
        {
            return _OrderTrackingRepository.GetAll().ToList();
        }

        public OrderTracking GetById(int id)
        {
            return _OrderTrackingRepository.GetById(id);
        }

        public void Insert(OrderTracking model)
        {
            _OrderTrackingRepository.Insert(model);
        }

        public void Update(OrderTracking model)
        {
            _OrderTrackingRepository.Update(model);
        }

        public OrderTracking GetById(string custId)
        {
            return _OrderTrackingRepository.GetById(custId);
        }
    }
}

