using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Metadata.Ecma335;

#nullable disable

namespace EasyCashIdentityProject.DataAccessLayerx.Migrations
{
    public partial class customeraccountprocess_add_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "customerAccountProcesses",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerAccountProcesses");
        }
    }
}
