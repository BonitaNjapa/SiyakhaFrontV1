namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ImgPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ImgPath");
        }
    }
}
