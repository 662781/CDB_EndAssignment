using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class _5th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Mortgages_MortgageID",
                table: "Houses");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Mortgages_MortgageID",
                table: "Houses",
                column: "MortgageID",
                principalTable: "Mortgages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Mortgages_MortgageID",
                table: "Houses");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Mortgages_MortgageID",
                table: "Houses",
                column: "MortgageID",
                principalTable: "Mortgages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
