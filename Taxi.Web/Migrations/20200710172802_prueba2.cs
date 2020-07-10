using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.Web.Migrations
{
    public partial class prueba2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_AspNetUsers_UserEntityId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "Trips",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_UserEntityId",
                table: "Trips",
                newName: "IX_Trips_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_AspNetUsers_UserId",
                table: "Trips",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_AspNetUsers_UserId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Trips",
                newName: "UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_UserId",
                table: "Trips",
                newName: "IX_Trips_UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_AspNetUsers_UserEntityId",
                table: "Trips",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
