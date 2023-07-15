using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveMa.Data.Migrations
{
    /// <inheritdoc />
    public partial class addReviewedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReviewedBy",
                table: "Leave",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewedBy",
                table: "Leave");
        }
    }
}
