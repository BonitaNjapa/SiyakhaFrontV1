using Data;
using Service.ProductOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ProductOrderRepository
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private DataContext _dataContext = null;
        private readonly IRepository<Data.ShoppingCartM.ProductOrder> _ProductOrderRepository;


        public ProductOrderRepository()
        {
            _dataContext = new DataContext();
            _ProductOrderRepository = new RepositoryService<Data.ShoppingCartM.ProductOrder>(_dataContext);

        }

        public void Delete(Data.ShoppingCartM.ProductOrder model)
        {
            _ProductOrderRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<Data.ShoppingCartM.ProductOrder> Find(Func<Data.ShoppingCartM.ProductOrder, bool> predicate)
        {
            return _ProductOrderRepository.Find(predicate);
        }

        public IEnumerable<Data.ShoppingCartM.ProductOrder> GetAll()
        {
            return _ProductOrderRepository.GetAll().ToList();
        }

        public Data.ShoppingCartM.ProductOrder GetById(int id)
        {
            return _ProductOrderRepository.GetById(id);
        }

        public void Insert(Data.ShoppingCartM.ProductOrder model)
        {
            _ProductOrderRepository.Insert(model);
        }

        public void Update(Data.ShoppingCartM.ProductOrder model)
        {
            _ProductOrderRepository.Update(model);
        }

        public Data.ShoppingCartM.ProductOrder GetById(string custId)
        {
            return _ProductOrderRepository.GetById(custId);
        }

    }
}
