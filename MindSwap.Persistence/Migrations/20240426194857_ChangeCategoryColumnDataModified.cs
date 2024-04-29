using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MindSwap.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCategoryColumnDataModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateModifired",
                table: "Posts",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateModifired",
                table: "Comments",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateModifired",
                table: "Categories",
                newName: "DateModified");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Posts",
                newName: "DateModifired");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Comments",
                newName: "DateModifired");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Categories",
                newName: "DateModifired");
        }
    }
}
