using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WritingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class reflectorUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Writings_AspNetUsers_UserId",
                table: "Writings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Writings",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Writings_UserId",
                table: "Writings",
                newName: "IX_Writings_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Writings",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Writings",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Article",
                table: "Writings",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddForeignKey(
                name: "FK_Writings_AspNetUsers_AuthorId",
                table: "Writings",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Writings_AspNetUsers_AuthorId",
                table: "Writings");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Writings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Writings_AuthorId",
                table: "Writings",
                newName: "IX_Writings_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Writings",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Writings",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Article",
                table: "Writings",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Writings_AspNetUsers_UserId",
                table: "Writings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
