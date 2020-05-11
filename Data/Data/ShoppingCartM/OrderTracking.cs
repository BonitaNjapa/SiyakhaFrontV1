using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ShoppingCartM
{
    public class OrderTracking
    {

        [Key]
        public int tracking_ID { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public string Recipient { get; set; }
        public int orderNo { get; set; }
        public virtual Order Order { get; set; }
    }


    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNo { get; set; }

        [ScaffoldColumn(false)]
        public string username { get; set; }

        [DisplayName("Order Date")]
        public System.DateTime dateCraeted { get; set; }

        //  [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(pattern: @"^\(?([0]{1})\)?[-. ]?([1-9]{1})[-. ]?([0-9]{8})$", ErrorMessage = "Entered phone format is not valid.")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        // [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(pattern: @"^\(?([0]{1})\)?[-. ]?([1-9]{1})[-. ]?([0-9]{8})$", ErrorMessage = "Entered phone format is not valid.")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        // [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        //  [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }


        //  [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [DataType(DataType.PostalCode)]
        [StringLength(4)]
        public string PostalCode { get; set; }

        //  [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Phone { get; set; }


        //  [DisplayName("Order Description")]
        public string OrdDescription { get; set; }

        //   [DisplayName("Total Price")]
        public decimal TotalPrice { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }




        public string Email { get; set; }
        public bool shipped { get; set; }
        public string status { get; set; }
        public virtual ICollection<OrderAddress> orderAddress { get; set; }
        public virtual ICollection<OrderItem> orderItems { get; set; }
        public virtual ICollection<OrderTracking> orderTracking { get; set; }
        // public bool Install { get; set; }
        public string CustNo { get; set; }
        public virtual Customer customer { get; set; }
        public bool packed { get; set; }
    }
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public bool replied { get; set; }
        public Nullable<DateTime> date_replied { get; set; }
        public bool accepted { get; set; }
        public Nullable<DateTime> date_accepted { get; set; }
        public bool shipped { get; set; }
        public string status { get; set; }
        public Nullable<DateTime> date_shipped { get; set; }
        [ForeignKey("Order")]
        public int Order_ID { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("Item")]
        public int ItemCode { get; set; }
        public virtual Item Item { get; set; }

    }

    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
    public class OrderAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int address_id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public int OrderNo { get; set; }
        public virtual Order Order { get; set; }

    }
}
