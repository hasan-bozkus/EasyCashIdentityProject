using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashIdentityProject.DataAccessLayerx.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customerAccountProcesses",
                columns: table => new
                {
                    CustomerAccountProcessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerAccountProcesses", x => x.CustomerAccountProcessID);
                });

            migrationBuilder.CreateTable(
                name: "customerAccounts",
                columns: table => new
                {
                    CustomerAccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAccountCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAccountBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankBranc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerAccounts", x => x.CustomerAccountID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerAccountProcesses");

            migrationBuilder.DropTable(
                name: "customerAccounts");
        }
    }
}
