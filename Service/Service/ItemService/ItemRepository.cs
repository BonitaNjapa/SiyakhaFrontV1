using Data;
using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ItemService
{
    public class ItemRepository : IItemRepository
    {
        private DataContext _dataContext = null;
        private readonly IRepository<Item> _itemRepository;


        public ItemRepository()
        {
            _dataContext = new DataContext();
            _itemRepository = new RepositoryService<Item>(_dataContext);

        }
        public void Delete(Item model)
        {
            _itemRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<Item> Find(Func<Item, bool> predicate)
        {
            return _itemRepository.Find(predicate).ToList();
        }

        public IEnumerable<Item> GetAll()
        {
            return _itemRepository.GetAll().ToList();
        }

        public Item GetById(int id)
        {
            return _itemRepository.GetById(id);
        }

        public void Insert(Item model)
        {
            _itemRepository.Insert(model);
        }

        public void Update(Item model)
        {
            _itemRepository.Update(model);
        }

        public Item GetById(string custId)
        {
            return _itemRepository.GetById(custId);
        }
    }
}

