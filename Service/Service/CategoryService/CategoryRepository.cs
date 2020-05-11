using Data;
using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CategoryService
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _dataContext = null;
        private readonly IRepository<Category> _CategoryRepository;


        public CategoryRepository()
        {
            _dataContext = new DataContext();
            _CategoryRepository = new RepositoryService<Category>(_dataContext);

        }

        public void Delete(Category model)
        {
            _CategoryRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return _CategoryRepository.Find(predicate);
        }

        public IEnumerable<Category> GetAll()
        {
            return _CategoryRepository.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            return _CategoryRepository.GetById(id);
        }

        public void Insert(Category model)
        {
            _CategoryRepository.Insert(model);
        }

        public void Update(Category model)
        {
            _CategoryRepository.Update(model);
        }

        public Category GetById(string custId)
        {
            return _CategoryRepository.GetById(custId);
        }
    }
}
