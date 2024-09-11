using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerlessToDoList.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItems_ToDoLists_ToDoListId",
                table: "ToDoListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoLists",
                table: "ToDoLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoListItems",
                table: "ToDoListItems");

            migrationBuilder.RenameTable(
                name: "ToDoLists",
                newName: "ToDoList");

            migrationBuilder.RenameTable(
                name: "ToDoListItems",
                newName: "ToDoListItem");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoListItems_ToDoListId",
                table: "ToDoListItem",
                newName: "IX_ToDoListItem_ToDoListId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ToDoList",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ToDoList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 11, 8, 41, 38, 179, DateTimeKind.Utc).AddTicks(2298),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "ToDoListItem",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Item",
                table: "ToDoListItem",
                type: "nvarchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoList",
                table: "ToDoList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoListItem",
                table: "ToDoListItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoList_Name",
                table: "ToDoList",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItem_ToDoList_ToDoListId",
                table: "ToDoListItem",
                column: "ToDoListId",
                principalTable: "ToDoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItem_ToDoList_ToDoListId",
                table: "ToDoListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoListItem",
                table: "ToDoListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoList",
                table: "ToDoList");

            migrationBuilder.DropIndex(
                name: "IX_ToDoList_Name",
                table: "ToDoList");

            migrationBuilder.RenameTable(
                name: "ToDoListItem",
                newName: "ToDoListItems");

            migrationBuilder.RenameTable(
                name: "ToDoList",
                newName: "ToDoLists");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoListItem_ToDoListId",
                table: "ToDoListItems",
                newName: "IX_ToDoListItems_ToDoListId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ToDoListItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "Item",
                table: "ToDoListItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ToDoLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ToDoLists",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 11, 8, 41, 38, 179, DateTimeKind.Utc).AddTicks(2298));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoListItems",
                table: "ToDoListItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoLists",
                table: "ToDoLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItems_ToDoLists_ToDoListId",
                table: "ToDoListItems",
                column: "ToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
