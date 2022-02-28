namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateAddded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAddded", c => c.DateTime(nullable: false));
        }
    }
}
