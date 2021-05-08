using Microsoft.EntityFrameworkCore.Migrations;

namespace CG.Infrastructure.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Receips",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceId",
                table: "Receips",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TurnId",
                table: "Receips",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receips_ProductId",
                table: "Receips",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Receips_ServiceId",
                table: "Receips",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Receips_TurnId",
                table: "Receips",
                column: "TurnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receips_Products_ProductId",
                table: "Receips",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receips_Services_ServiceId",
                table: "Receips",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receips_Turns_TurnId",
                table: "Receips",
                column: "TurnId",
                principalTable: "Turns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receips_Products_ProductId",
                table: "Receips");

            migrationBuilder.DropForeignKey(
                name: "FK_Receips_Services_ServiceId",
                table: "Receips");

            migrationBuilder.DropForeignKey(
                name: "FK_Receips_Turns_TurnId",
                table: "Receips");

            migrationBuilder.DropIndex(
                name: "IX_Receips_ProductId",
                table: "Receips");

            migrationBuilder.DropIndex(
                name: "IX_Receips_ServiceId",
                table: "Receips");

            migrationBuilder.DropIndex(
                name: "IX_Receips_TurnId",
                table: "Receips");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Receips");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Receips");

            migrationBuilder.DropColumn(
                name: "TurnId",
                table: "Receips");
        }
    }
}
