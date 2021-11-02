namespace Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Company = c.String(),
                        Designation = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Fax = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        Address = c.String(),
                        Notes = c.String(),
                        Email01 = c.String(),
                        Email02 = c.String(),
                        Email03 = c.String(),
                        Email04 = c.String(),
                        Contact01 = c.String(),
                        Contact02 = c.String(),
                        Contact03 = c.String(),
                        Contact04 = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Domain",
                c => new
                    {
                        DomainId = c.Int(nullable: false, identity: true),
                        DomainName = c.String(),
                        DomainRegistrationDate = c.DateTime(nullable: false),
                        DomainBillingDate = c.DateTime(nullable: false),
                        RenewalPrice = c.String(),
                        DHStatus = c.Boolean(nullable: false),
                        Notes = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DomainId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Hosting",
                c => new
                    {
                        HostingId = c.Int(nullable: false, identity: true),
                        HostingDate = c.DateTime(nullable: false),
                        HostingBillingDate = c.DateTime(nullable: false),
                        HostingRenewalPrice = c.String(),
                        OtherServices = c.String(),
                        CustomerId = c.Int(nullable: false),
                        HostingPackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HostingId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.HostingPackage", t => t.HostingPackageId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.HostingPackageId);
            
            CreateTable(
                "dbo.HostingPackage",
                c => new
                    {
                        HostingPackageId = c.Int(nullable: false, identity: true),
                        HostingPackageName = c.String(),
                    })
                .PrimaryKey(t => t.HostingPackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hosting", "HostingPackageId", "dbo.HostingPackage");
            DropForeignKey("dbo.Hosting", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Domain", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Hosting", new[] { "HostingPackageId" });
            DropIndex("dbo.Hosting", new[] { "CustomerId" });
            DropIndex("dbo.Domain", new[] { "CustomerId" });
            DropTable("dbo.HostingPackage");
            DropTable("dbo.Hosting");
            DropTable("dbo.Domain");
            DropTable("dbo.Customer");
        }
    }
}
