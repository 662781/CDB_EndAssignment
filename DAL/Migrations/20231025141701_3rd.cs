using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class _3rd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Mortgages_HouseID",
                table: "Mortgages",
                column: "HouseID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mortgages_Houses_HouseID",
                table: "Mortgages",
                column: "HouseID",
                principalTable: "Houses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mortgages_Houses_HouseID",
                table: "Mortgages");

            migrationBuilder.DropIndex(
                name: "IX_Mortgages_HouseID",
                table: "Mortgages");
        }
    }
}
