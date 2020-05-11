using BusinessLogic;
using Data;
using Data.ShoppingCartM;
using Microsoft.AspNet.Identity;
using Model;
using Model.HelperToast;
using Service.OrderService;
using Service.OrderTrackingService;
using SiyakhaFrontV1.Controllers.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SiyakhaFrontV1.Controllers
{
    public class ShoppingController : Controller
    {
        private CartBusiness cart_Service = new CartBusiness();
        private ItemBusiness item_Service = new ItemBusiness();
        private Order_Business Order_Business = new Order_Business();
        private OrderItemRepository _orderItemRepository = new OrderItemRepository();
        private OrderRepository _orderRepository = new OrderRepository();
        private OrderAddressRepository _orderAddressRepository = new OrderAddressRepository();
        private OrderTrackingRepository _orderTrackingRepository = new OrderTrackingRepository();
        private DepartmentBusiness department_Service;
        public ActionResult Index(int? id)
        {
            var items_results = new List<Item>();
            try
            {
                if (id != null)
                {
                    if (id == 0)
                    {
                        items_results = item_Service.GetItems().ToList();
                        ViewBag.Department = "All Departments";
                    }
                    else
                    {
                        int notnull = Convert.ToInt16(id);
                        items_results = item_Service.GetItems().Where(x => x.Department.Department_ID == (int)id).ToList();
                        ViewBag.Department = department_Service.GetDepartment(notnull).Department_Name;
                    }
                }
                else
                {
                    items_results = item_Service.GetItems().ToList();
                    ViewBag.Department = "All Departments";
                }
            }
            catch (Exception) { }
            return View(items_results);
        }
        public ActionResult increaseItemQuantity(string id)
        {
            var item = cart_Service.GetCartItems().FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                cart_Service.increaseItemQuantity(id: id);
                this.AddToastMessage("Success!", item.Item.Name + " quantity has been increased", ToastType.Success);
                return RedirectToAction("ShoppingCart");
            }
            else
                this.AddToastMessage("Item Error!", "An unexpected error has occured", ToastType.Error);
            return RedirectToAction("ShoppingCart");
        }
        public ActionResult decreaseItemQuantity(string id)
        {
            var item = cart_Service.GetCartItems().FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                cart_Service.decreaseItemQuantity(id: id);
                this.AddToastMessage("Success!", item.Item.Name + " quantity has been decreased", ToastType.Success);
                return RedirectToAction("ShoppingCart");
            }
            else
                this.AddToastMessage("Item Error!", " An unexpected error has occured", ToastType.Error);
            return RedirectToAction("ShoppingCart");
        }
        public ActionResult add_to_cart(int id)
        {
            var UserName = User.Identity.GetUserName();
            int qty = 1;
            var item = item_Service.GetItem(id);
            CartItem ct = new CartItem();
            if (item != null)
            {
                cart_Service.UpdateQuantity(id, qty);
                //cart_Service.UpdateCart(item.ItemCode,item.Cart_Items.);
                cart_Service.AddItemToCart(id, UserName);
                this.AddToastMessage("Success!", item.Name + " quantity has been added", ToastType.Success);
                return RedirectToAction("Index");
            }
         
            else
                return RedirectToAction("Not_Found", "Error");
        }
        public ActionResult remove_from_cart(string id)
        {
            var item = cart_Service.GetCartItems().FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                cart_Service.RemoveItemFromCart(id: id);
                this.AddToastMessage("Success!", item.Item.Name + "  has been removed", ToastType.Success);
                return RedirectToAction("ShoppingCart");
            }
            else
                return RedirectToAction("Not_Found", "Error");
        }
        public ActionResult ShoppingCart()
        {
            ViewBag.Total = cart_Service.GetCartTotal(cart_Service.GetCartID());
            ViewBag.TotalQTY = cart_Service.GetCartItems().FindAll(x => x.cartId == cart_Service.GetCartID()).Sum(q => q.quantity);
            return View(cart_Service.GetCartItems().FindAll(x => x.cartId == cart_Service.GetCartID()));
        }
        [HttpPost]
        public ActionResult ShoppingCart(List<CartItem> items)
        {
            foreach (var i in items)
            {
                cart_Service.UpdateCart(i.Id, i.quantity);
            }
            return RedirectToAction("ShoppingCart");
        }
        public ActionResult countCartItems()
        {
            var username = User.Identity.GetUserName();
            int qty = cart_Service.GetCartItems().Sum(x => x.quantity);
            return Content(qty.ToString());
        }
        public ActionResult Checkout()
        {
            if (cart_Service.GetCartItems().Count == 0)
            {
                ViewBag.Err = "Opps... you should have atleast one cart item, please shop a few items";
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("HowToGetMyOrder");
        }
        [Authorize]
        public ActionResult HowToGetMyOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HowToGetMyOrder(FormCollection formCollection)
        {
           /* Session["street_number"]*/ string streetNume = formCollection["StreetNumber"];
            /*Session["street_name"] */ string streetName = formCollection["street_name"];
            Session["City"] = formCollection["City"];
            Session["State"] = formCollection["State"];
            Session["ZipCode"] = formCollection["ZipCode"];
            Session["Country"] = formCollection["Country"];
            return RedirectToAction("PlaceOrder", new { id = "deliver" });
        }
        [Authorize]
        public ActionResult PlaceOrder(string id)
        {
            /* Find the details of the customer placing the order*/
            DataContext dataContext = new DataContext();
            var user = dataContext.Users.ToList().Find(x=>x.Email == HttpContext.User.Identity.Name);
            var customer = new Customer(); 
            /* Place the order */
            _orderRepository.Insert(new Order()
            {
                Email = user.Email,
                dateCraeted = DateTime.Now,
                shipped = false,
                status = "Awaiting Payment",
                TotalPrice = cart_Service.GetCartTotal(cart_Service.GetCartID())
            });
            // db.SaveChanges();
            //order_Service.AddOrder(customer);
            /* Get the last placed order by the customer */
            var order = _orderRepository.GetAll() //db.Orders.ToList()
                .FindAll(x => x.Email == user.Email)
                .OrderByDescending(x => x.dateCraeted)
                .FirstOrDefault();
            /* If the customer requests delivery, save order address */
            if (id == "deliver")
            {
                //   db.SaveChanges();
                try
                {
                    _orderAddressRepository.Insert(new OrderAddress()
                    {
                        OrderNo = order.OrderNo,
                        //  street_number = Convert.ToInt16(Session["street_number"].ToString()),
                        street = Session["street_name"].ToString(),
                        city = Session["City"].ToString(),
                        // state = Session["State"].ToString(),
                        zipcode = Session["ZipCode"].ToString()
                        // Country = Session["Country"].ToString(),

                        //Building_Name = "",
                        //Floor = "",
                        //Contact_Number = "",
                        //Comments = "",
                        //Address_Type = ""
                    });
                }
                catch (Exception x)
                {
                   var m = x.Message;
                }
            }
            /* Migrate cart items to map as order items */
            //   order_Service.AddOrderItems(order, cart_Service.GetCartItems());
            var items = cart_Service.GetCartItems();

            foreach (var item in items)
            {
                var x = new OrderItem()
                {
                    Order_ID = order.OrderNo,
                    ItemCode = item.ItemdId,
                    quantity = item.quantity,
                    price = item.price
                   
                };

            
                //   ob.updateStock_bot(x.item_id, x.quantity);
                // db.OrderItems.Add(x);
                // db.SaveChanges();
                _orderItemRepository.Insert(x);
            }
            /* Empty the cart items */
            cart_Service.EmptyCart();
            /* Update Order Tracking Report */
            _orderTrackingRepository.Insert(new OrderTracking()
            {
                orderNo = order.OrderNo,
                date = DateTime.Now,
                status = "Awaiting Payment",
                Recipient = ""
            });

            //Redirect to payment
             return RedirectToAction("Payment", new { id = order.OrderNo });
           // return RedirectToAction("Payment",new { id = order.OrderNo });
        }
        public ActionResult Payment(int id)
        {
            DataContext context = new DataContext();
            //var order = _orderRepository.GetById(id); //db.Orders.Find(id);
            //ViewBag.Order = order;

            //ViewBag.Account = context.Users.Find(order.Email);   //db.Customers.Find(order.custId);
            //ViewBag.name = order.FirstName;
            //ViewBag.lname = order.LastName;
            //ViewBag.Address = context.OrderAddresses.ToList().Find(x => x.OrderNo == order.OrderNo);
            //ViewBag.Items = context.OrderItems.ToList().FindAll(x => x.Order_ID == order.OrderNo);
            //ViewBag.Total = order.TotalPrice;
            OrderDetailConFirm odcf = new OrderDetailConFirm();
            Order orderT = _orderRepository.GetById(id);
            odcf.order = orderT;
            odcf.address = context.OrderAddresses.ToList().Find(x => x.OrderNo == _orderRepository.GetById(id).OrderNo);
            ViewBag.Items = context.OrderItems.ToList().FindAll(x => x.Order_ID == orderT.OrderNo).ToList();
            
            
            // context.OrderItems.Include(c => c.Item).Where(x => x.Order_ID == _orderRepository.GetById(id).OrderNo).ToList();


            #region email
            //try
            //{
            //    string url = "<a href=" + "/Shopping/Payment/" + id + " >  here" + "</a>";
            //    string table = "<br/>" +
            //                   "Items in this order<br/>" +
            //                   "<table>";
            //    table += "<tr>" +
            //             "<th>Item</th>"
            //             +
            //             "<th>Quantity</th>"
            //             +
            //             "<th>Price</th>" +
            //             "</tr>";
            //    foreach (var item in (List<OrderItem>)ViewBag.Items)
            //    {
            //        string itemsinoder = "<tr> " +
            //                             "<td>" + item.Item.Name + " </td>" +
            //                             "<td>" + item.quantity + " </td>" +
            //                             "<td>R " + item.price + " </td>" +
            //                             "<tr/>";
            //        table += itemsinoder;
            //    }

            //    table += "<tr>" +
            //             "<th></th>"
            //             +
            //             "<th></th>"
            //             +
            //             "<th>" + order.TotalPrice.ToString("R0.00") + "</th>" +
            //             "</tr>";
            //    table += "</table>";

            //    //var client = new SendGridClient("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");
            //    //var from = new EmailAddress("aabonile@gmail.com", "Company");
            //    var subject = "Order " + id + " | Awaiting Payment";
            //    //var to = new EmailAddress(((Customer)ViewBag.Account).Email, ((Customer)ViewBag.Account).FirstName + " " + ((Customer)ViewBag.Account).LastName);
            //    var htmlContent = "Hi " + order.FirstName + ", Your order was placed, you can securely pay your order from " + url + table;
            //    //var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            //    //var response = client.SendEmailAsync(msg);
            //}
            //catch (Exception ex)
            //{

            //}
            #endregion
            //return View();
            return View(odcf);
        }
        public ActionResult Secure_Payment(int id)
        {
            var order = _orderRepository.GetById(id);//db.Orders.Find(id);
            return Redirect(PaymentLink(cart_Service.GetCartTotal(order.OrderNo.ToString()).ToString(), "Order Payment | Order No: " + order.OrderNo, order.OrderNo.ToString()));
        }
        //public ActionResult Return_Url(string id)
        //{
        //    var order = db.Orders.Find(id);

        //    ViewBag.Order = order;
        //    ViewBag.Account = customer_Service.GetCustomer(order.Email);
        //    ViewBag.Address = address_Service.GetOrderAddresses().Find(x => x.Order_ID == order.Order_ID);
        //    ViewBag.Items = order_Service.GetOrderItems(order.Order_ID);
        //    ViewBag.Total = order_Service.GetOrderTotal(order.Order_ID);
        //    return View();
        //}
        public ActionResult Payment_Successfull(string id)
        {
            try
            {
                var order = _orderRepository.GetById(id);
                var items = _orderItemRepository.Find(predicate: x => x.Order_ID == order.OrderNo).ToList();
                foreach (var tem in items)
                {
                    cart_Service.UpdateQuantity(tem.Item.ItemCode,tem.ItemCode);
                }
                cart_Service.AddPayment(order);
                OrderDetailConFirm odcf = new OrderDetailConFirm();
                Order orderT = _orderRepository.GetById(id);
                odcf.order = orderT;
                //odcf.address = context.OrderAddresses.ToList().Find(x => x.OrderNo == _orderRepository.GetById(id).OrderNo);
                //ViewBag.Items = context.OrderItems.ToList().FindAll(x => x.Order_ID == orderT.OrderNo).ToList();
                //Order_Business.EstimateDeliveryDateReport(order);
                //if (affiliate_Service.GetAffiliateJoiners().FirstOrDefault(x => x.New_Customer_Email == order.Email) != null)
                //{ /* deposit benefits */
                //    affiliate_Service.PayAffiliates(order.Email, (decimal)order_Service.GetOrderTotal(order.Order_ID));
                //}
            }
            catch (Exception ex) { }
            return View();
        }

        public string PaymentLink(string totalCost, string paymentSubjetc, string order_id)
        {

            string paymentMode = ConfigurationManager.AppSettings["PaymentMode"], site, merchantId, merchantKey, returnUrl, cancelUrl, PF_NotifyURL;

            if (paymentMode == "test")
            {
                site = "https://sandbox.payfast.co.za/eng/process?";
                merchantId = "10017134";
                merchantKey = "dzhxjfvzun252";
            }
            else if (paymentMode == "live")
            {
                site = "https://www.payfast.co.za/eng/process?";
                merchantId = ConfigurationManager.AppSettings["PF_MerchantID"];
                merchantKey = ConfigurationManager.AppSettings["PF_MerchantKey"];
            }
            else
            {
                throw new InvalidOperationException("Payment method unknown.");
            }
            var stringBuilder = new StringBuilder();
            //PF_NotifyURL = Url.Action("Payment_Successfull", "Shopping",
            //    new System.Web.Routing.RouteValueDictionary(new { id = order_id }),
            //    "http", Request.Url.Host);
            //returnUrl = Url.Action("Order_Details", "Orders",
            //    new System.Web.Routing.RouteValueDictionary(new { id = order_id }),
            //    "http", Request.Url.Host);
            //cancelUrl = Url.Action("Index", "Shopping",
            //    new System.Web.Routing.RouteValueDictionary(new { id = order_id }),
            //    "http", Request.Url.Host);

            PF_NotifyURL = ConfigurationManager.AppSettings["NotifyURL"];
            returnUrl =Url.Action();
            cancelUrl = ConfigurationManager.AppSettings["CancelURL"];
            /* mechant details */
            stringBuilder.Append("&merchant_id=" + HttpUtility.HtmlEncode(merchantId));
            stringBuilder.Append("&merchant_key=" + HttpUtility.HtmlEncode(merchantKey));
            stringBuilder.Append("&return_url=" + HttpUtility.HtmlEncode(returnUrl));
            stringBuilder.Append("&cancel_url=" + HttpUtility.HtmlEncode(cancelUrl));
            stringBuilder.Append("&notify_url=" + HttpUtility.HtmlEncode(PF_NotifyURL));
            /* buyer details */
            Data.DataContext db = new Data.DataContext();
            var customer = _orderRepository.Find(x => x.OrderNo.ToString() == order_id).FirstOrDefault();
           

            //db.Orders.FirstOrDefault(x => x.OrderNo.ToString() == order_id).customer;
            if (customer != null)
            {
                stringBuilder.Append("&name_first=" + HttpUtility.HtmlEncode(customer.FirstName));
                stringBuilder.Append("&name_last=" + HttpUtility.HtmlEncode(customer.LastName));
                stringBuilder.Append("&email_address=" + HttpUtility.HtmlEncode(customer.Email));
                //stringBuilder.Append("&cell_number=" + HttpUtility.HtmlEncode(customer.phone));
            }
            /* Transaction details */
            var order = _orderRepository.GetById(Convert.ToInt32(order_id));
            if (order != null)
            {
               decimal pricetot = (decimal)cart_Service.GetCartTotal(cart_Service.GetCartID());
                stringBuilder.Append("&m_payment_id=" + HttpUtility.HtmlEncode(order.OrderNo));
                stringBuilder.Append("&amount=" + HttpUtility.HtmlEncode((double)order.TotalPrice));
                stringBuilder.Append("&item_name=" + HttpUtility.HtmlEncode(paymentSubjetc));
                stringBuilder.Append("&item_description=" + HttpUtility.HtmlEncode(paymentSubjetc));

                stringBuilder.Append("&email_confirmation=" + HttpUtility.HtmlEncode("1"));
                stringBuilder.Append("&confirmation_address=" + HttpUtility.HtmlEncode(ConfigurationManager.AppSettings["PF_ConfirmationAddress"]));
            }

            return (site + stringBuilder);
        }
       
    }
}