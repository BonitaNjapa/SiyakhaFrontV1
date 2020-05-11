using Data.ShoppingCartM;
using Service.DepartmentService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DepartmentBusiness
    {
        private DepartmentRepository dataContext = new DepartmentRepository();


        public List<Department> GetDepartments()
        {
            return dataContext.GetAll().ToList(); //dataContext.Departments.ToList();
        }
        public bool AddDepartment(Department department)
        {
            try
            {
                //dataContext.Departments.Add(department);
                //dataContext.SaveChanges();
                dataContext.Insert(department);
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public bool UpdateDepartment(Department department)
        {
            try
            {

                Data.DataContext db = new Data.DataContext();
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                //dataContext.Update(department);
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public bool RemoveDepartment(Department department)
        {
            try
            {
                //dataContext.Departments.Remove(department);
                //dataContext.SaveChanges();
                dataContext.Delete(department);
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public Department GetDepartment(int department_id)
        {
            return dataContext.GetById(department_id); //dataContext.Departments.Find(department_id);
        }
        //public List<Item> Department_items(int? id)
        //{
        //    return find_by_id(id)Items.ToList();
        //}
    }
}
