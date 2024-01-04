namespace PHE2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_tr_account_roles",
                c => new
                    {
                        guid = c.Guid(nullable: false),
                        account_guid = c.Guid(nullable: false),
                        role_guid = c.Guid(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.guid)
                .ForeignKey("dbo.tb_m_accounts", t => t.account_guid, cascadeDelete: true)
                .ForeignKey("dbo.tb_m_roles", t => t.role_guid, cascadeDelete: true)
                .Index(t => t.account_guid)
                .Index(t => t.role_guid);
            
            CreateTable(
                "dbo.tb_m_accounts",
                c => new
                    {
                        guid = c.Guid(nullable: false),
                        password = c.String(),
                        otp = c.Int(nullable: false),
                        is_used = c.Boolean(nullable: false),
                        expired_date = c.DateTime(nullable: false),
                        approved_by_admin = c.Boolean(nullable: false),
                        approved_by_manager = c.Boolean(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.guid)
                .ForeignKey("dbo.tb_m_users", t => t.guid, cascadeDelete: true)
                .Index(t => t.guid);
            
            CreateTable(
                "dbo.tb_m_characteristics",
                c => new
                    {
                        guid = c.Guid(nullable: false),
                        business_field = c.String(),
                        company_type = c.String(),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.guid)
                .ForeignKey("dbo.tb_m_accounts", t => t.guid, cascadeDelete: true)
                .Index(t => t.guid);
            
            CreateTable(
                "dbo.tb_m_users",
                c => new
                    {
                        guid = c.Guid(nullable: false),
                        name = c.String(),
                        email = c.String(maxLength: 255),
                        telephone = c.String(),
                        photo = c.String(),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.guid);
            
            CreateTable(
                "dbo.tb_m_projects",
                c => new
                    {
                        guid = c.Guid(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        user_guid = c.Guid(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.guid)
                .ForeignKey("dbo.tb_m_users", t => t.user_guid, cascadeDelete: true)
                .Index(t => t.user_guid);
            
            CreateTable(
                "dbo.tb_tr_user_projects",
                c => new
                    {
                        guid = c.Guid(nullable: false),
                        user_guid = c.Guid(nullable: false),
                        project_guid = c.Guid(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.guid)
                .ForeignKey("dbo.tb_m_projects", t => t.project_guid)
                .ForeignKey("dbo.tb_m_users", t => t.user_guid)
                .Index(t => t.user_guid)
                .Index(t => t.project_guid);
            
            CreateTable(
                "dbo.tb_m_roles",
                c => new
                    {
                        guid = c.Guid(nullable: false),
                        name = c.String(),
                        created_date = c.DateTime(nullable: false),
                        modified_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.guid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_tr_account_roles", "role_guid", "dbo.tb_m_roles");
            DropForeignKey("dbo.tb_tr_user_projects", "user_guid", "dbo.tb_m_users");
            DropForeignKey("dbo.tb_tr_user_projects", "project_guid", "dbo.tb_m_projects");
            DropForeignKey("dbo.tb_m_projects", "user_guid", "dbo.tb_m_users");
            DropForeignKey("dbo.tb_m_accounts", "guid", "dbo.tb_m_users");
            DropForeignKey("dbo.tb_m_characteristics", "guid", "dbo.tb_m_accounts");
            DropForeignKey("dbo.tb_tr_account_roles", "account_guid", "dbo.tb_m_accounts");
            DropIndex("dbo.tb_tr_user_projects", new[] { "project_guid" });
            DropIndex("dbo.tb_tr_user_projects", new[] { "user_guid" });
            DropIndex("dbo.tb_m_projects", new[] { "user_guid" });
            DropIndex("dbo.tb_m_characteristics", new[] { "guid" });
            DropIndex("dbo.tb_m_accounts", new[] { "guid" });
            DropIndex("dbo.tb_tr_account_roles", new[] { "role_guid" });
            DropIndex("dbo.tb_tr_account_roles", new[] { "account_guid" });
            DropTable("dbo.tb_m_roles");
            DropTable("dbo.tb_tr_user_projects");
            DropTable("dbo.tb_m_projects");
            DropTable("dbo.tb_m_users");
            DropTable("dbo.tb_m_characteristics");
            DropTable("dbo.tb_m_accounts");
            DropTable("dbo.tb_tr_account_roles");
        }
    }
}
