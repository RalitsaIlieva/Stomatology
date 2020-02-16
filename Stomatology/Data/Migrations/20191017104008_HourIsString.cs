using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stomatology.Data.Migrations
{
    public partial class HourIsString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Hour",
                table: "Appointments",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Hour",
                table: "Appointments",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
