using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class _4th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseID",
                table: "Mortgages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuyerID",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MortgageID",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_BuyerID",
                table: "Houses",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_MortgageID",
                table: "Houses",
                column: "MortgageID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Buyers_BuyerID",
                table: "Houses",
                column: "BuyerID",
                principalTable: "Buyers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Mortgages_MortgageID",
                table: "Houses",
                column: "MortgageID",
                principalTable: "Mortgages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Buyers_BuyerID",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Mortgages_MortgageID",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_BuyerID",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_MortgageID",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "HouseID",
                table: "Mortgages");

            migrationBuilder.DropColumn(
                name: "BuyerID",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "MortgageID",
                table: "Houses");
        }
    }
}
