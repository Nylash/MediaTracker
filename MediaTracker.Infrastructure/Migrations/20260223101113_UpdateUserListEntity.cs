using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserListEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserLists_UserId_ListName",
                table: "UserLists");

            migrationBuilder.AlterColumn<string>(
                name: "ListName",
                table: "UserLists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "UserLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "UserLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserLists_UserId_ListName",
                table: "UserLists",
                columns: new[] { "UserId", "ListName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserLists_UserId_ListName",
                table: "UserLists");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "UserLists");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "UserLists");

            migrationBuilder.AlterColumn<string>(
                name: "ListName",
                table: "UserLists",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_UserLists_UserId_ListName",
                table: "UserLists",
                columns: new[] { "UserId", "ListName" },
                unique: true,
                filter: "[ListName] IS NOT NULL");
        }
    }
}
