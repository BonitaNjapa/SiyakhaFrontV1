using Data;
using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderTrackingService
{
    public class OrderAddressRepository : IOrderAddressRepository
    {

        private DataContext _dataContext = null;
        private readonly IRepository<OrderAddress> _OrderAddressRepository;


        public OrderAddressRepository()
        {
            _dataContext = new DataContext();
            _OrderAddressRepository = new RepositoryService<OrderAddress>(_dataContext);

        }

        public void Delete(OrderAddress model)
        {
            _OrderAddressRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<OrderAddress> Find(Func<OrderAddress, bool> predicate)
        {
            return _OrderAddressRepository.Find(predicate);
        }

        public IEnumerable<OrderAddress> GetAll()
        {
            return _OrderAddressRepository.GetAll().ToList();
        }

        public OrderAddress GetById(int id)
        {
            return _OrderAddressRepository.GetById(id);
        }

        public void Insert(OrderAddress model)
        {
            _OrderAddressRepository.Insert(model);
        }

        public void Update(OrderAddress model)
        {
            _OrderAddressRepository.Update(model);
        }

        public OrderAddress GetById(string custId)
        {
            return _OrderAddressRepository.GetById(custId);
        }
    }
}
