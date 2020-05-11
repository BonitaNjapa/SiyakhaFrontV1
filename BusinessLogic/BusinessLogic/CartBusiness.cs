using Data;
using Data.ShoppingCartM;
using Service.CartService;
using Service.ItemService;
using Service.ProductOrderRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CartBusiness
    {
        private  CartItemRepository _cartItemRepository = new CartItemRepository();
        private  ItemRepository _itemRepository = new ItemRepository();
        private  CartRepository _cartRepository = new CartRepository();
        private  ProductOrderRepository _productOrderRepository = new ProductOrderRepository();
        //private ApplicationDbContext dataContext;
        public static string shoppingCartID { get; set; }
        public ProductOrder ProductOrder { get; private set; }
        public const string CartSessionKey = "CartId";
        public void AddItemToCart(int id, string username)
        {
            shoppingCartID = GetCartID();
            ProductOrder = new ProductOrder();
            var item = _itemRepository.GetById(id);
            if (item != null)
            {

                //FoodOrder
                var foodItem =
                    _productOrderRepository.Find(x => x.cart_id == shoppingCartID && x.item_id == item.ItemCode).FirstOrDefault();
                var cartItem =
                    _cartItemRepository.Find(x => x.cartId == shoppingCartID && x.ItemdId == item.ItemCode).FirstOrDefault();
                if (cartItem == null)
                {
                    var cart = _cartRepository.GetById(shoppingCartID);
                    if (cart == null)
                    {
                        _cartRepository.Insert(model: new Cart()
                        {

                            CartID = shoppingCartID,
                            date_created = DateTime.Now

                        });
                        //dataContext.SaveChanges();
                    }

                    _cartItemRepository.Insert(model: new CartItem()
                    {
                        Id = Guid.NewGuid().ToString(),
                        cartId = shoppingCartID,
                        ItemdId = item.ItemCode,
                        quantity = 1,
                        price = item.Price,
                        UserEmail = username
                    }
                        );
                    //food.item_id = cartItem.item_id;
                    //food.cart_id = cartItem.cart_id;
                    //food.quantity = cartItem.quantity;
                    //food.UserEmail = cartItem.UserEmail;
                    //dataContext.FoodOrders.Add(food);




                    _productOrderRepository.Insert(model: new ProductOrder()
                    {
                        cart_item_id = Guid.NewGuid().ToString(),
                        cart_id = shoppingCartID,
                        item_id = item.ItemCode,
                        quantity = 1,
                        price = item.Price,
                        ItemName = item.Name,
                        UserEmail = username,
                        Picture = item.Picture,
                        OrderDate = DateTime.Now.Date.ToString(),
                        OrderStatus = "Not Cheked Out"
                    });

                }
                else
                {
                    cartItem.quantity++;
                    foodItem.quantity++;
                }
                //dataContext.SaveChanges();
            }
        }
        public void UpdateQuantity(int id, int qty)
        {
            DataContext db = new DataContext();
            var qtyUpdate = _itemRepository.GetById(id);
            qtyUpdate.QuantityInStock = qtyUpdate.QuantityInStock - qty;
            db.Entry(qtyUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void increaseItemQuantity(string id)
        {
            shoppingCartID = GetCartID();

            var item = _cartItemRepository.GetById(id);
            if (item != null)
            {
                var cartItem =
                   _cartItemRepository.Find(predicate: x => x.cartId == shoppingCartID && x.ItemdId == item.ItemdId).FirstOrDefault();
                //var OrderItem =
                //   _productOrderRepository.Find(predicate: x => x.cart_id == shoppingCartID && x.item_id == item.ItemdId).FirstOrDefault();
                if (cartItem != null)
                {
                    cartItem.quantity += 1; 
                    _cartItemRepository.Update(model: cartItem);
                   // _productOrderRepository.Delete(model: OrderItem);
                }
                //dataContext.SaveChanges();
            }
        }
        public void decreaseItemQuantity(string id)
        {
            shoppingCartID = GetCartID();

            var item = _cartItemRepository.GetById(id);
            if (item != null)
            {
                var cartItem =
                   _cartItemRepository.Find(predicate: x => x.cartId == shoppingCartID && x.ItemdId == item.ItemdId).FirstOrDefault();
                //var OrderItem =
                //   _productOrderRepository.Find(predicate: x => x.cart_id == shoppingCartID && x.item_id == item.ItemdId).FirstOrDefault();
                if (cartItem != null)
                {
                    if (cartItem.quantity == 1)
                        _cartItemRepository.Delete(cartItem);
                    else
                    {
                        cartItem.quantity -= 1;
                        _cartItemRepository.Update(model: cartItem);
                    }
                   
                    // _productOrderRepository.Delete(model: OrderItem);
                }
                //dataContext.SaveChanges();
            }
        }

        public void RemoveItemFromCart(string id)
        {
            shoppingCartID = GetCartID();

            var item = _cartItemRepository.GetById(id);
            if (item != null)
            {
                var cartItem =
                   _cartItemRepository.Find(predicate: x => x.cartId == shoppingCartID && x.ItemdId == item.ItemdId).FirstOrDefault();
                var OrderItem =
                   _productOrderRepository.Find(predicate: x => x.cart_id == shoppingCartID && x.item_id == item.ItemdId).FirstOrDefault();
                if (cartItem != null)
                {
                    _cartItemRepository.Delete(model: cartItem);
                    _productOrderRepository.Delete(model: OrderItem);
                }
                //dataContext.SaveChanges();
            }
        }
        public List<CartItem> GetCartItems()
        {
            shoppingCartID = GetCartID();
            return _cartItemRepository.Find(predicate: x => x.cartId == shoppingCartID).ToList();
        }
        public void UpdateCart(string id, int qty)
        {
            var item = _cartItemRepository.GetById(id);
            if (qty < 0)
                item.quantity = qty / -1;
            else if (qty == 0)
                RemoveItemFromCart(item.cartId);
            else if (item.Item.QuantityInStock < qty)
                item.quantity = item.Item.QuantityInStock;
            else
                item.quantity = qty;
            //  dataContext.SaveChanges();
        }
        public decimal GetCartTotal(string id)
        {
            double amount = 0;
            foreach (var item in _cartItemRepository.Find(predicate: x => x.cartId == id))
            {
                amount += (item.price * item.quantity);
            }
            return (decimal)amount;
        }
        public void EmptyCart()
        {
            shoppingCartID = GetCartID();
            //foreach (var item in _cartItemRepository.Find(predicate: x => x.cartId == shoppingCartID))
            //{
            //    //db.Cart_Items.Attach(item);
            //    //db.Cart_Items.Remove(item);
             
           // }
             _cartItemRepository.DeleteRange(_cartItemRepository.Find(predicate: x => x.cartId == shoppingCartID));
            try
            {
                //var cart = _cartRepository.GetById(shoppingCartID).CartID;

                //cart.Insert(cart.Length - 1,"Removed");
                _cartRepository.Delete(_cartRepository.GetById(shoppingCartID));
                // dataContext.Carts.Remove(dataContext.Carts.Find(shoppingCartID));
                //dataContext.SaveChanges();
            }
            catch (Exception x)
            {
                var m = x.Message;
            }
        }
        public string GetCartID()
        {
            if (System.Web.HttpContext.Current.Session[name: CartSessionKey] == null)
            {
                if (!String.IsNullOrWhiteSpace(value: System.Web.HttpContext.Current.User.Identity.Name))
                {
                    System.Web.HttpContext.Current.Session[name: CartSessionKey] = System.Web.HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid temp = Guid.NewGuid();
                    System.Web.HttpContext.Current.Session[name: CartSessionKey] = temp.ToString();
                }
            }

            return System.Web.HttpContext.Current.Session[name: CartSessionKey].ToString();
        }

        public void AddPayment(Order order)
        {
            DataContext db = new DataContext();

            var payment = new Payment(){
                AmountPaid = (double)order.TotalPrice,
                custId = order.Email,
                Date = DateTime.Now,
                PaymentFor = "Online Order No" + order.OrderNo.ToString(),
                PaymentMethod = "Payfast"
            };
            db.Payments.Add(payment);
            db.SaveChanges();
        }
    }
}

