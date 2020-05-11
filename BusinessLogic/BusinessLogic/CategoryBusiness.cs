using Data.ShoppingCartM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class CategoryBusiness
    {

        private Service.CategoryService.CategoryRepository _categoryService = new Service.CategoryService.CategoryRepository();

       

        public List<Category> GetCategories()
        {
            return _categoryService.GetAll().ToList();
        }
        public bool AddCategory(Category category)
        {
            try
            {
                //dataContext.Categories.Add(category);
                //dataContext.SaveChanges();
                _categoryService.Insert(category);
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public bool UpdateCategory(Category category)
        {
            try
            {
                //dataContext.Entry(category).State = EntityState.Modified;
                //dataContext.SaveChanges();
                _categoryService.Update(category);
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public bool RemoveCategory(Category category)
        {
            try
            {
                //dataContext.Categories.Remove(category);
                //dataContext.SaveChanges();
                _categoryService.Delete(category);
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public Category GetCategory(int category_id)
        {
            return _categoryService.GetById(category_id); //dataContext.Categories.Find(category_id);
        }
    }
}
