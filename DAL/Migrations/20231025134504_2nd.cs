using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class _2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Mortgages");

            migrationBuilder.AddColumn<byte[]>(
                name: "Created",
                table: "Mortgages",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "GetDate() ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Mortgages");

            migrationBuilder.AddColumn<byte[]>(
                name: "TimeStamp",
                table: "Mortgages",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
