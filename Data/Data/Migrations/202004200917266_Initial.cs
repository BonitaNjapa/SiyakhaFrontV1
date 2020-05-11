namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        cartId = c.String(maxLength: 128),
                        ItemdId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        OrderId = c.Int(),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.cartId)
                .ForeignKey("dbo.Items", t => t.ItemdId)
                .Index(t => t.cartId)
                .Index(t => t.ItemdId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.String(nullable: false, maxLength: 128),
                        date_created = c.DateTime(nullable: false),
                        userId = c.String(),
                    })
                .PrimaryKey(t => t.CartID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemCode = c.Int(nullable: false, identity: true),
                        Department_ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 80),
                        Description = c.String(nullable: false, maxLength: 255),
                        QuantityInStock = c.Int(nullable: false),
                        Picture = c.Binary(),
                        Price = c.Double(nullable: false),
                        CostPrice = c.Double(nullable: false),
                        Category_Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemCode)
                .ForeignKey("dbo.Categories", t => t.Category_Category_ID)
                .ForeignKey("dbo.Departments", t => t.Department_ID)
                .Index(t => t.Department_ID)
                .Index(t => t.Category_Category_ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Department_ID = c.Int(nullable: false, identity: true),
                        Department_Name = c.String(nullable: false, maxLength: 80),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Department_ID)
                .Index(t => t.Department_Name, unique: true, name: "Department_Index");
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Category_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        Department_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Category_ID)
                .ForeignKey("dbo.Departments", t => t.Department_ID)
                .Index(t => t.Name, unique: true, name: "Category_Index")
                .Index(t => t.Department_ID);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        cart_item_id = c.String(nullable: false, maxLength: 128),
                        cart_id = c.String(),
                        item_id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        ItemName = c.String(),
                        UserEmail = c.String(),
                        Picture = c.Binary(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderStatus = c.String(),
                        OrderDate = c.String(),
                        DayOfWik = c.String(),
                        OrderId = c.Int(),
                        Item_ItemCode = c.Int(),
                    })
                .PrimaryKey(t => t.cart_item_id)
                .ForeignKey("dbo.Items", t => t.Item_ItemCode)
                .Index(t => t.Item_ItemCode);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        TitleId = c.Int(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        isActive = c.Boolean(),
                        Image = c.Binary(),
                        ImageType = c.String(),
                        IDno = c.String(),
                        DoB = c.String(),
                        gender = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.OrderTrackings",
                c => new
                    {
                        tracking_ID = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        status = c.String(),
                        Recipient = c.String(),
                        orderNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.tracking_ID)
                .ForeignKey("dbo.Orders", t => t.orderNo)
                .Index(t => t.orderNo);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderNo = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        dateCraeted = c.DateTime(nullable: false),
                        FirstName = c.String(maxLength: 160),
                        LastName = c.String(maxLength: 160),
                        Address = c.String(maxLength: 70),
                        City = c.String(maxLength: 40),
                        PostalCode = c.String(maxLength: 4),
                        Phone = c.String(maxLength: 24),
                        OrdDescription = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(),
                        shipped = c.Boolean(nullable: false),
                        status = c.String(),
                        CustNo = c.String(),
                        customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderNo)
                .ForeignKey("dbo.AspNetUsers", t => t.customer_Id)
                .Index(t => t.customer_Id);
            
            CreateTable(
                "dbo.OrderAddresses",
                c => new
                    {
                        address_id = c.Int(nullable: false, identity: true),
                        street = c.String(),
                        city = c.String(),
                        zipcode = c.String(),
                        OrderNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.address_id)
                .ForeignKey("dbo.Orders", t => t.OrderNo)
                .Index(t => t.OrderNo);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Item_ItemCode = c.Int(),
                        Order_OrderNo = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Items", t => t.Item_ItemCode)
                .ForeignKey("dbo.Orders", t => t.Order_OrderNo)
                .Index(t => t.Item_ItemCode)
                .Index(t => t.Order_OrderNo);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        replied = c.Boolean(nullable: false),
                        date_replied = c.DateTime(),
                        accepted = c.Boolean(nullable: false),
                        date_accepted = c.DateTime(),
                        shipped = c.Boolean(nullable: false),
                        status = c.String(),
                        date_shipped = c.DateTime(),
                        Order_ID = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                        Item_ItemCode = c.Int(),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Items", t => t.Item_ItemCode)
                .ForeignKey("dbo.Orders", t => t.Order_ID)
                .Index(t => t.Order_ID)
                .Index(t => t.Item_ItemCode);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.IdentityUserClaims", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderTrackings", "orderNo", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "Item_ItemCode", "dbo.Items");
            DropForeignKey("dbo.OrderDetails", "Order_OrderNo", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Item_ItemCode", "dbo.Items");
            DropForeignKey("dbo.OrderAddresses", "OrderNo", "dbo.Orders");
            DropForeignKey("dbo.Orders", "customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CartItems", "ItemdId", "dbo.Items");
            DropForeignKey("dbo.ProductOrders", "Item_ItemCode", "dbo.Items");
            DropForeignKey("dbo.Items", "Department_ID", "dbo.Departments");
            DropForeignKey("dbo.Items", "Category_Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Department_ID", "dbo.Departments");
            DropForeignKey("dbo.CartItems", "cartId", "dbo.Carts");
            DropIndex("dbo.OrderItems", new[] { "Item_ItemCode" });
            DropIndex("dbo.OrderItems", new[] { "Order_ID" });
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderNo" });
            DropIndex("dbo.OrderDetails", new[] { "Item_ItemCode" });
            DropIndex("dbo.OrderAddresses", new[] { "OrderNo" });
            DropIndex("dbo.Orders", new[] { "customer_Id" });
            DropIndex("dbo.OrderTrackings", new[] { "orderNo" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Item_ItemCode" });
            DropIndex("dbo.Categories", new[] { "Department_ID" });
            DropIndex("dbo.Categories", "Category_Index");
            DropIndex("dbo.Departments", "Department_Index");
            DropIndex("dbo.Items", new[] { "Category_Category_ID" });
            DropIndex("dbo.Items", new[] { "Department_ID" });
            DropIndex("dbo.CartItems", new[] { "ItemdId" });
            DropIndex("dbo.CartItems", new[] { "cartId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderItems");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.OrderAddresses");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderTrackings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ProductOrders");
            DropTable("dbo.Categories");
            DropTable("dbo.Departments");
            DropTable("dbo.Items");
            DropTable("dbo.Carts");
            DropTable("dbo.CartItems");
        }
    }
}
