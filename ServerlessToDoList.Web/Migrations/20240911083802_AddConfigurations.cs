using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerlessToDoList.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItems_ToDoLists_ToDoListId",
                table: "ToDoListItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "ToDoListId",
                table: "ToDoListItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItems_ToDoLists_ToDoListId",
                table: "ToDoListItems",
                column: "ToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItems_ToDoLists_ToDoListId",
                table: "ToDoListItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "ToDoListId",
                table: "ToDoListItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItems_ToDoLists_ToDoListId",
                table: "ToDoListItems",
                column: "ToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id");
        }
    }
}
