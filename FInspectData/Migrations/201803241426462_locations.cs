namespace FInspectData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinalInspections", "MfgLocation", c => c.String());
            AddColumn("dbo.FinalInspections", "InspectionLocation", c => c.String());
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nonconformances", "Inspector_Id", c => c.Int());
            AddColumn("dbo.FinalInspections", "Inspector_Id", c => c.Int());
        }
    }
}
