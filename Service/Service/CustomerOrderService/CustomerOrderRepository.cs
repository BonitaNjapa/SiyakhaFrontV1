using Data;
using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerOrderService
{
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        private DataContext _dataContext = null;
        private readonly IRepository<CustomerOrder> _CustomerOrderRepository;


        public CustomerOrderRepository()
        {
            _dataContext = new DataContext();
            _CustomerOrderRepository = new RepositoryService<CustomerOrder>(_dataContext);

        }

        public void Delete(CustomerOrder model)
        {
            _CustomerOrderRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<CustomerOrder> Find(Func<CustomerOrder, bool> predicate)
        {
            return _CustomerOrderRepository.Find(predicate);
        }

        public IEnumerable<CustomerOrder> GetAll()
        {
            return _CustomerOrderRepository.GetAll().ToList();
        }

        public CustomerOrder GetById(int id)
        {
            return _CustomerOrderRepository.GetById(id);
        }

        public void Insert(CustomerOrder model)
        {
            _CustomerOrderRepository.Insert(model);
        }

        public void Update(CustomerOrder model)
        {
            _CustomerOrderRepository.Update(model);
        }

        public CustomerOrder GetById(string custId)
        {
            return _CustomerOrderRepository.GetById(custId);
        }
    }
}
