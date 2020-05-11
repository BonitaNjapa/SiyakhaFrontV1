using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CategoryService
{
    public interface ICategoryRepository
    {
        Category GetById(Int32 id);
        IEnumerable<Category> GetAll();
        void Insert(Category model);
        void Update(Category model);
        void Delete(Category model);
        IEnumerable<Category> Find(Func<Category, bool> predicate);
    }
}
