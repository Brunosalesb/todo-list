using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ToDoList.Infra.Migrations
{
    public partial class LastDateUpdateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "ToDo",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "ToDo");
        }
    }
}
