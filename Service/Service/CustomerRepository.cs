using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerRepository : ICustomer
    {
        private DataContext _dataContext = null;
        private readonly IRepository<Customer> _CartItemRepository;


        public CustomerRepository()
        {
            _dataContext = new DataContext();
            _CartItemRepository = new RepositoryService<Customer>(_dataContext);

        }
        public void Delete(Customer model)
        {
            _CartItemRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
        {
            return _CartItemRepository.Find(predicate).ToList();
        }

        public List<Customer> GetAll()
        {
            return _CartItemRepository.GetAll().ToList();
        }

        public Customer GetById(int id)
        {
            return _CartItemRepository.GetById(id);
        }

        public void Insert(Customer model)
        {
            _CartItemRepository.Insert(model);
        }

        public void Update(Customer model)
        {
            _CartItemRepository.Update(model);
        }

        public Customer GetById(string custId)
        {
          return  _CartItemRepository.GetById(custId);
        }
    }
}
