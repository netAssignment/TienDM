namespace BookMgnt.Migrations.Book
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CategoriesID = c.Int(nullable: false),
                        Author = c.String(nullable: false),
                        Introduce = c.String(),
                        imagePath = c.String(),
                        pubYear = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoriesID, cascadeDelete: true)
                .Index(t => t.CategoriesID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CategoriesID", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoriesID" });
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
        }
    }
}
