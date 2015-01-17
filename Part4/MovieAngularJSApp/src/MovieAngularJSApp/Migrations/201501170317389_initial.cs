using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Model;
using System;

namespace MovieAngularJSApp.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Director = c.String(),
                        Title = c.String()
                    })
                .PrimaryKey("PK_Movie", t => t.Id);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Movie");
        }
    }
}