namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MobilePhoneNo", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MobilePhoneNo");
        }
    }
}
