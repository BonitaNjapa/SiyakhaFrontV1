using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Model;

namespace Service
{
    public interface ICart_Item : IDisposable
    {
        Cart_Item GetById(Int32 id);

        Cart_Item GetById(string id);
        List<Cart_Item> GetAll();
        void Insert(Cart_Item model);
        void Update(Cart_Item model);
        void Delete(Cart_Item model);
        IEnumerable<Cart_Item> Find(Func<Cart_Item, bool> predicate);
    }
    public interface ICategory : IDisposable
    {
        Category GetById(Int32 id);
        List<Category> GetAll();
        void Insert(Category model);
        void Update(Category model);
        void Delete(Category model);
        IEnumerable<Category> Find(Func<Category, bool> predicate);
    }
    public interface IComment : IDisposable
    {
        Comment GetById(Int32 id);
        List<Comment> GetAll();
        void Insert(Comment model);
        void Update(Comment model);
        void Delete(Comment model);
        IEnumerable<Comment> Find(Func<Comment, bool> predicate);
    }

    public interface ICompany : IDisposable
    {
        Company GetById(Int32 id);
        List<Company> GetAll();
        void Insert(Company model);
        void Update(Company model);
        void Delete(Company model);
        IEnumerable<Company> Find(Func<Company, bool> predicate);
    }

    public interface ICustomer : IDisposable
    {
        Customer GetById(Int32 id);
        List<Customer> GetAll();
        void Insert(Customer model);
        void Update(Customer model);
        void Delete(Customer model);
        IEnumerable<Customer> Find(Func<Customer, bool> predicate);
    }
    public interface IDelivery : IDisposable
    {
        Delivery GetById(Int32 id);
        List<Delivery> GetAll();
        void Insert(Delivery model);
        void Update(Delivery model);
        void Delete(Delivery model);
        IEnumerable<Delivery> Find(Func<Delivery, bool> predicate);
    }
    public interface IDriver : IDisposable
    {
        Driver GetById(Int32 id);
        List<Driver> GetAll();
        void Insert(Driver model);
        void Update(Driver model);
        void Delete(Driver model);
        IEnumerable<Driver> Find(Func<Driver, bool> predicate);
    }

    public interface IEmployee : IDisposable
    {
        Employee GetById(Int32 id);
        List<Employee> GetAll();
        void Insert(Employee model);
        void Update(Employee model);
        void Delete(Employee model);
        IEnumerable<Employee> Find(Func<Employee, bool> predicate);
    }

    public interface IEquipment : IDisposable
    {
        Equipment GetById(Int32 id);
        List<Equipment> GetAll();
        void Insert(Equipment model);
        void Update(Equipment model);
        void Delete(Equipment model);
        IEnumerable<Equipment> Find(Func<Equipment, bool> predicate);
    }
    public interface IFarmer : IDisposable
    {
        Farmer GetById(Int32 id);
        List<Farmer> GetAll();
        void Insert(Farmer model);
        void Update(Farmer model);
        void Delete(Farmer model);
        IEnumerable<Farmer> Find(Func<Farmer, bool> predicate);
    }

    public interface ILocation : IDisposable
    {
        Location GetById(Int32 id);
        List<Location> GetAll();
        void Insert(Location model);
        void Update(Location model);
        void Delete(Location model);
        IEnumerable<Location> Find(Func<Location, bool> predicate);
    }

    public interface IMassage : IDisposable
    {
        Massage GetById(Int32 id);
        List<Massage> GetAll();
        void Insert(Massage model);
        void Update(Massage model);
        void Delete(Massage model);
        IEnumerable<Massage> Find(Func<Massage, bool> predicate);
    }
    public interface INotification : IDisposable
    {
        Notification GetById(Int32 id);
        List<Notification> GetAll();
        void Insert(Notification model);
        void Update(Notification model);
        void Delete(Notification model);
        IEnumerable<Notification> Find(Func<Notification , bool> predicate);
    }

    public interface IOrder : IDisposable
    {
        Order GetById(Int32 id);
        Order GetById(string id);
        List<Order> GetAll();
        void Insert(Order model);
        void Update(Order model);
        void Delete(Order model);
        IEnumerable<Order> Find(Func<Order, bool> predicate);
    }
    public interface IOrder_Address  : IDisposable
    {
        Order_Address GetById(Int32 id);
        List<Order_Address> GetAll();
        void Insert(Order_Address model);
        void Update(Order_Address model);
        void Delete(Order_Address model);
        IEnumerable<Order_Address> Find(Func<Order_Address, bool> predicate);
    }
    public interface IOrder_Item : IDisposable
    {
        Order_Item GetById(Int32 id);
        List<Order_Item> GetAll();
        void Insert(Order_Item model);
        void Update(Order_Item model);
        void Delete(Order_Item model);
        IEnumerable<Order_Item> Find(Func<Order_Item, bool> predicate);
    }

    public interface IOrder_Tracking: IDisposable
    {
        Order_Tracking GetById(Int32 id);
        List<Order_Tracking> GetAll();
        void Insert(Order_Tracking model);
        void Update(Order_Tracking model);
        void Delete(Order_Tracking model);
        IEnumerable<Order_Tracking> Find(Func<Order_Tracking, bool> predicate);
    }

    public interface IPayment : IDisposable
    {
        Payment GetById(Int32 id);
        List<Payment> GetAll();
        void Insert(Payment model);
        void Update(Payment model);
        void Delete(Payment model);
        IEnumerable<Payment> Find(Func<Payment, bool> predicate);
    }

    public interface IScheduleCategory : IDisposable
    {
        ScheduleCategory GetById(Int32 id);
        List<ScheduleCategory> GetAll();
        void Insert(ScheduleCategory model);
        void Update(ScheduleCategory model);
        void Delete(ScheduleCategory model);
        IEnumerable<ScheduleCategory> Find(Func<ScheduleCategory, bool> predicate);
    }
    public interface ISchedulingDelivery : IDisposable
    {
        SchedulingDelivery GetById(Int32 id);
        List<SchedulingDelivery> GetAll();
        void Insert(SchedulingDelivery model);
        void Update(SchedulingDelivery model);
        void Delete(SchedulingDelivery model);
        IEnumerable<SchedulingDelivery> Find(Func<SchedulingDelivery, bool> predicate);
    }
    public interface ISurvey : IDisposable
    {
        Survey GetById(Int32 id);
        List<Survey> GetAll();
        void Insert(Survey model);
        void Update(Survey model);
        void Delete(Survey model);      
        IEnumerable<Survey> Find(Func<Survey, bool> predicate);
    }
    public interface IWarehouse : IDisposable
    {
        Warehouse GetById(Int32 id);
        List<Warehouse> GetAll();
        void Insert(Warehouse model);
        void Update(Warehouse model);
        void Delete(Warehouse model);
        IEnumerable<Warehouse> Find(Func<Warehouse, bool> predicate);
    }

}

