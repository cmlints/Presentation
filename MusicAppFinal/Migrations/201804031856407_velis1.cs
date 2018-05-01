namespace MusicAppFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class velis1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MusicApps", "Song", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MusicApps", "Song", c => c.String(nullable: false, maxLength: 7));
        }
    }
}
