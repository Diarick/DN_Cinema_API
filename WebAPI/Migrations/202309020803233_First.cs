namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(unicode: false),
                        description = c.String(unicode: false),
                        rating = c.Single(nullable: false),
                        image = c.String(unicode: false),
                        created_at = c.DateTime(nullable: false, precision: 0),
                        updated_at = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
