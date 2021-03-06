namespace VidlyV6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeNamePopulateData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes Set Name = 'PayAsYouGo' WHERE Id = 1");
            Sql("UPDATE MembershipTypes Set Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes Set Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes Set Name = 'Yearly' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
