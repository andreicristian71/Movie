namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Actiune')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Comedie')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Drama')");
        }

        public override void Down()
        {
        }
    }
}
