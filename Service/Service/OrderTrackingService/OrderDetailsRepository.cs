using Data;
using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderTrackingService
{
   public class OrderDetailsRepository
    {

        private DataContext _dataContext = null;
        private readonly IRepository<OrderDetails> _OrderDetailsRepository;


        public OrderDetailsRepository()
        {
            _dataContext = new DataContext();
            _OrderDetailsRepository = new RepositoryService<OrderDetails>(_dataContext);

        }

        public void Delete(OrderDetails model)
        {
            _OrderDetailsRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<OrderDetails> Find(Func<OrderDetails, bool> predicate)
        {
            return _OrderDetailsRepository.Find(predicate);
        }

        public List<OrderDetails> GetAll()
        {
            return _OrderDetailsRepository.GetAll().ToList();
        }

        public OrderDetails GetById(int id)
        {
            return _OrderDetailsRepository.GetById(id);
        }

        public void Insert(OrderDetails model)
        {
            _OrderDetailsRepository.Insert(model);
        }

        public void Update(OrderDetails model)
        {
            _OrderDetailsRepository.Update(model);
        }

        public OrderDetails GetById(string custId)
        {
            return _OrderDetailsRepository.GetById(custId);
        }
    }
}
