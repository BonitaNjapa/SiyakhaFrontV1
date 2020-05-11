using Data.ShoppingCartM;
using Service.OrderService;
using Service.OrderTrackingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Order_Business
    {
        // private ApplicationDbContext db = new ApplicationDbContext();

        private OrderRepository _OrderRepository = new OrderRepository();
        private OrderTrackingRepository _orderTracking = new OrderTrackingRepository();
        private OrderAddressRepository _orderAddress = new OrderAddressRepository();

        /// 
        /// customer orders
        /// 
        public List<Order> cust_all()
        {
            return _OrderRepository.GetAll();  //db.Orders.ToList();
        }
        public List<Order> cust_find_by_status(string status)
        {
            return _OrderRepository.Find(predicate: x => x.status.ToLower() == status.ToLower()).ToList();  //db.Orders.Where(p => p.status.ToLower() == status.ToLower()).ToList();
        }
        public Order cust_find_by_id(int id)
        {
            return _OrderRepository.GetById(id);///db.Orders.Find(id);
        }
        public List<OrderItem> cust_Order_items(int id)
        {
            return cust_find_by_id(id).orderItems.ToList();
        }

        public List<OrderTracking> get_tracking_report(int? id)
        {
            return _orderTracking.Find(predicate: x => x.orderNo == id).ToList();  //db.Order_Trackings.Where(x => x.Order_Id == id).ToList();
        }
        public void mark_as_packed(int id)
        {
            var order = cust_find_by_id(id);
            order.packed = true;
            if (_orderAddress.Find(predicate: p => p.OrderNo == id) != null)
            {
                order.status = "With courier";

             _orderTracking.Insert(new OrderTracking(){
                 orderNo = order.OrderNo,
                 date = DateTime.Now,
                 status = "Order Packed, Now with our courier",
                 Recipient = ""
             });
            }

            //db.SaveChanges();
        }
        public void schedule_delivery(int Order_Id, DateTime date)
        {
            //Order_Id
            var order = cust_find_by_id(Order_Id);
            order.status = "Scheduled for delivery";
            //order tracking
            _orderTracking.Insert(new OrderTracking(){
                orderNo = order.OrderNo,
                date = DateTime.Now,
                status = "Scheduled for delivery on " + date.ToLongDateString(),
                Recipient = ""
            });
            //db.SaveChanges();
        }
    }
}
