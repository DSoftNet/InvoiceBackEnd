using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Infrastructure.Migrations
{
    public partial class invoice_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subsidiary_UserId",
                table: "Subsidiary",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_User_UserId",
                table: "Client",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subsidiary_User_UserId",
                table: "Subsidiary",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRol_User_UserId",
                table: "UserRol",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_User_UserId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Subsidiary_User_UserId",
                table: "Subsidiary");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRol_User_UserId",
                table: "UserRol");

            migrationBuilder.DropIndex(
                name: "IX_Subsidiary_UserId",
                table: "Subsidiary");
        }
    }
}
