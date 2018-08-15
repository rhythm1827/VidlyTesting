namespace VidlyV6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateColumnDateTime : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET DateOfBirth = CAST('1980-01-01' AS DATETIME) WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
