using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashIdentityProject.DataAccessLayerx.Migrations
{
    public partial class mig_add_customer_relationproccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverID",
                table: "customerAccountProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderID",
                table: "customerAccountProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_customerAccountProcesses_ReceiverID",
                table: "customerAccountProcesses",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_customerAccountProcesses_SenderID",
                table: "customerAccountProcesses",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_customerAccountProcesses_customerAccounts_ReceiverID",
                table: "customerAccountProcesses",
                column: "ReceiverID",
                principalTable: "customerAccounts",
                principalColumn: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_customerAccountProcesses_customerAccounts_SenderID",
                table: "customerAccountProcesses",
                column: "SenderID",
                principalTable: "customerAccounts",
                principalColumn: "CustomerAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customerAccountProcesses_customerAccounts_ReceiverID",
                table: "customerAccountProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_customerAccountProcesses_customerAccounts_SenderID",
                table: "customerAccountProcesses");

            migrationBuilder.DropIndex(
                name: "IX_customerAccountProcesses_ReceiverID",
                table: "customerAccountProcesses");

            migrationBuilder.DropIndex(
                name: "IX_customerAccountProcesses_SenderID",
                table: "customerAccountProcesses");

            migrationBuilder.DropColumn(
                name: "ReceiverID",
                table: "customerAccountProcesses");

            migrationBuilder.DropColumn(
                name: "SenderID",
                table: "customerAccountProcesses");
        }
    }
}
