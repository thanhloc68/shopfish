namespace ShopFish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Usernames = c.String(),
                        Passwords = c.String(),
                        NameUser = c.String(),
                        Gender = c.String(),
                        Tel = c.String(),
                        Addresss = c.String(),
                        email = c.String(),
                        createsdate = c.DateTime(nullable: false),
                        IDRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.IDRole, cascadeDelete: true)
                .Index(t => t.IDRole);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderDate = c.String(),
                        Descriptions = c.String(),
                        Amount = c.Single(nullable: false),
                        AccountsID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountsID_ID)
                .Index(t => t.AccountsID_ID);
            
            CreateTable(
                "dbo.Ordersdetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Orders_ID = c.Int(),
                        Products_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.Orders_ID)
                .ForeignKey("dbo.Products", t => t.Products_ID)
                .Index(t => t.Orders_ID)
                .Index(t => t.Products_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Product_Code = c.String(),
                        Name = c.String(),
                        Image = c.String(),
                        Descriptions = c.String(),
                        LivingEnvironment = c.String(),
                        GeneralFeatures = c.String(),
                        Quanlity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Hot = c.String(),
                        Createdates = c.DateTime(),
                        Datesupdate = c.DateTime(nullable: false),
                        viewcount = c.Int(nullable: false),
                        Categories_ID = c.Int(),
                        Suppliers_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Categories_ID)
                .ForeignKey("dbo.Suppliers", t => t.Suppliers_ID)
                .Index(t => t.Categories_ID)
                .Index(t => t.Suppliers_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        IDRole = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IDRole);
            
            CreateTable(
                "dbo.ContactViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 10),
                        email = c.String(nullable: false),
                        address = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Createdate = c.DateTime(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        email = c.String(),
                        address = c.String(),
                        Content = c.String(),
                        Createdate = c.DateTime(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Quanlity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Hot = c.String(),
                        Createdates = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ResignViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Usernames = c.String(nullable: false),
                        Passwords = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        NameUser = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Tel = c.String(nullable: false, maxLength: 10),
                        Addresss = c.String(nullable: false),
                        email = c.String(nullable: false),
                        createsdate = c.DateTime(),
                        IDRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "IDRole", "dbo.Roles");
            DropForeignKey("dbo.Products", "Suppliers_ID", "dbo.Suppliers");
            DropForeignKey("dbo.Ordersdetails", "Products_ID", "dbo.Products");
            DropForeignKey("dbo.Products", "Categories_ID", "dbo.Categories");
            DropForeignKey("dbo.Ordersdetails", "Orders_ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "AccountsID_ID", "dbo.Accounts");
            DropIndex("dbo.Products", new[] { "Suppliers_ID" });
            DropIndex("dbo.Products", new[] { "Categories_ID" });
            DropIndex("dbo.Ordersdetails", new[] { "Products_ID" });
            DropIndex("dbo.Ordersdetails", new[] { "Orders_ID" });
            DropIndex("dbo.Orders", new[] { "AccountsID_ID" });
            DropIndex("dbo.Accounts", new[] { "IDRole" });
            DropTable("dbo.ResignViewModels");
            DropTable("dbo.ProductViewModels");
            DropTable("dbo.Feedback");
            DropTable("dbo.ContactViewModels");
            DropTable("dbo.Roles");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Ordersdetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Accounts");
        }
    }
}
