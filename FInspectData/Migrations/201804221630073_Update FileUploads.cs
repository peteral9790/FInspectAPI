namespace FInspectData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFileUploads : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinalInspectionUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Attachment1 = c.String(),
                        Attachment2 = c.String(),
                        Attachment3 = c.String(),
                        Attachment4 = c.String(),
                        Attachment5 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FinalInspections", "InspectionFiles_Id", c => c.Int());
            CreateIndex("dbo.FinalInspections", "InspectionFiles_Id");
            AddForeignKey("dbo.FinalInspections", "InspectionFiles_Id", "dbo.FinalInspectionUploads", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinalInspections", "InspectionFiles_Id", "dbo.FinalInspectionUploads");
            DropIndex("dbo.FinalInspections", new[] { "InspectionFiles_Id" });
            DropColumn("dbo.FinalInspections", "InspectionFiles_Id");
            DropTable("dbo.FinalInspectionUploads");
        }
    }
}
