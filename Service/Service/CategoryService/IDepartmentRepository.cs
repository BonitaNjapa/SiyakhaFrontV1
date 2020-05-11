using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CategoryService
{
    public interface IDepartmentRepository : IDisposable
    {
        Department GetById(Int32 id);
        IEnumerable<Department> GetAll();
        void Insert(Department model);
        void Update(Department model);
        void Delete(Department model);
        IEnumerable<Department> Find(Func<Department, bool> predicate);
    }
}
