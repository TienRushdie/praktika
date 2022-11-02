namespace praktika.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detail",
                c => new
                    {
                        Detail_number = c.Int(nullable: false),
                        Detail_name = c.String(nullable: false, maxLength: 1000),
                        Detail_Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Detail_number);
            
            CreateTable(
                "dbo.Detail_machine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Machine_n = c.Int(nullable: false),
                        Detail_n = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Detail_storage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        storage_n = c.Int(nullable: false),
                        detail_n = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Machine",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Machinenumber = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 1000),
                        Type = c.String(nullable: false, maxLength: 1000),
                        Date_of_start = c.DateTime(nullable: false, storeType: "date"),
                        Work_time = c.Int(nullable: false),
                        Date_of_end = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Repairer_machine",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Machine_n = c.Int(nullable: false),
                        repairer_tab_n = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Repairers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tab_n = c.Int(nullable: false),
                        FIO = c.String(nullable: false, maxLength: 1000),
                        experience = c.Int(nullable: false),
                        Phone_number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Storage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Storage_n = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 1000),
                        Square = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Storage");
            DropTable("dbo.Repairers");
            DropTable("dbo.Repairer_machine");
            DropTable("dbo.Machine");
            DropTable("dbo.Detail_storage");
            DropTable("dbo.Detail_machine");
            DropTable("dbo.Detail");
        }
    }
}
