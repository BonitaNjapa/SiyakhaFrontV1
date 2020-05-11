using Data.ShoppingCartM;
using Service.ItemService;
using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using System.Data;
using System.Data.Entity;
using System.Web.Mvc;

namespace BusinessLogic
{
    public class ItemBusiness : Controller
    {
        private ItemRepository _itemRepository = new ItemRepository();


        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetAll(); //dataContext.Items.Include(i => i.Department).ToList();
        }
        public bool AddItem(Item item)
        {
            try
            {
                _itemRepository.Insert(item);
                //dataContext.Items.Add(item);
                //dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }

        //public void UpdateQuantity(int id, int qty)
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    var qytUpdate = db.Items.Find(id);
        //    qytUpdate.QuantityInStock = qytUpdate.QuantityInStock - qty;
        //}
        public bool UpdateItem(Item item)
        {
            try
            {
                Data.DataContext db = new Data.DataContext();
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public bool RemoveItem(Item item)
        {
            try
            {
                _itemRepository.Delete(item);
                //dataContext.Items.Remove(item);
                //dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public Item GetItem(int item_id)
        {
            return _itemRepository.GetById(id: item_id); //dataContext.Items.Find(item_id);
        }


        public string imageUrI(HttpPostedFileBase file,Item item)
        {

            if (item != null)
            {
                string ext = Path.GetExtension(file.FileName);
                if (ext != ".png" && ext != ".PNG" && ext != ".jpg" && ext != ".JPG" && ext != ".jpeg" && ext != ".JPEG")
                {

                }
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Images/"), Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
                    file.SaveAs(path);
                    return  path.Substring(path.LastIndexOf("\\") + 1);
                }
                catch (Exception e)
                {
                    var err = e.Message;
                }
            }
            return "Error Check Image";
        }
    }
}
