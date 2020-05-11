using Data;
using Data.ShoppingCartM;
using Service.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DepartmentService
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private DataContext _dataContext = null;
        private readonly IRepository<Department> _DepartmentRepository;


        public DepartmentRepository()
        {
            _dataContext = new DataContext();
            _DepartmentRepository = new RepositoryService<Department>(_dataContext);

        }

        public void Delete(Department model)
        {
            _DepartmentRepository.Delete(model);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }

        public IEnumerable<Department> Find(Func<Department, bool> predicate)
        {
            return _DepartmentRepository.Find(predicate);
        }

        public IEnumerable<Department> GetAll()
        {
            return _DepartmentRepository.GetAll().ToList();
        }

        public Department GetById(int id)
        {
            return _DepartmentRepository.GetById(id);
        }

        public void Insert(Department model)
        {
            _DepartmentRepository.Insert(model);
        }

        public void Update(Department model)
        {
            _DepartmentRepository.Update(model);
        }

        public Department GetById(string custId)
        {
            return _DepartmentRepository.GetById(custId);
        }
    }
}
