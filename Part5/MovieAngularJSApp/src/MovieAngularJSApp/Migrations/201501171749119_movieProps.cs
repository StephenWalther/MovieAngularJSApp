using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Model;
using System;

namespace MovieAngularJSApp.Migrations
{
    public partial class movieProps : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn("Movie", "ReleaseDate", c => c.DateTime(nullable: false));
            
            migrationBuilder.AddColumn("Movie", "TicketPrice", c => c.Decimal(nullable: false));
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Movie", "ReleaseDate");
            
            migrationBuilder.DropColumn("Movie", "TicketPrice");
        }
    }
}