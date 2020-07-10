using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.Web.Migrations
{
    public partial class SolIdEr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Taxis_Taxiid",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "Taxiid",
                table: "Trips",
                newName: "TaxiId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_Taxiid",
                table: "Trips",
                newName: "IX_Trips_TaxiId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Taxis",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Taxis_TaxiId",
                table: "Trips",
                column: "TaxiId",
                principalTable: "Taxis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Taxis_TaxiId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TaxiId",
                table: "Trips",
                newName: "Taxiid");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_TaxiId",
                table: "Trips",
                newName: "IX_Trips_Taxiid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Taxis",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Taxis_Taxiid",
                table: "Trips",
                column: "Taxiid",
                principalTable: "Taxis",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
