namespace VidlyV6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateOfBirth");
        }
    }
}
