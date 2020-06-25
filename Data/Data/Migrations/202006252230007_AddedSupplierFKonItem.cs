namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSupplierFKonItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Branches", "Supplier_Id", c => c.Int());
            AddColumn("dbo.Items", "SupplierId", c => c.Int(nullable: false,defaultValue: 0));
            CreateIndex("dbo.Branches", "Supplier_Id");
            CreateIndex("dbo.Items", "SupplierId");
            AddForeignKey("dbo.Branches", "Supplier_Id", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.Items", "SupplierId", "dbo.Suppliers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Branches", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Items", new[] { "SupplierId" });
            DropIndex("dbo.Branches", new[] { "Supplier_Id" });
            DropColumn("dbo.Items", "SupplierId");
            DropColumn("dbo.Branches", "Supplier_Id");
            DropTable("dbo.Suppliers");
        }
    }
}
