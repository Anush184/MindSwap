using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MindSwap.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCanceledApprovedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Posts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Comments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Comments");
        }
    }
}
