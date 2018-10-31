namespace MovieStore.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoviesTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        YearRelasesed = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        GenreTable_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenreTables", t => t.GenreTable_Id)
                .Index(t => t.GenreTable_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoviesTables", "GenreTable_Id", "dbo.GenreTables");
            DropIndex("dbo.MoviesTables", new[] { "GenreTable_Id" });
            DropTable("dbo.MoviesTables");
            DropTable("dbo.GenreTables");
        }
    }
}
