using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViopOrtalama.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class pass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "AspNetRoles");
        }
    }
}
