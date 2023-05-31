using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAPI.Migrations
{
    public partial class newColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KindOfStoragte",
                table: "storage",
                newName: "KindOfStorage");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "storage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "storage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "storage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "stateofstorage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "stateofstorage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "stateofstorage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "storage");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "storage");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "storage");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "stateofstorage");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "stateofstorage");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "stateofstorage");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "product");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "product");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "KindOfStorage",
                table: "storage",
                newName: "KindOfStoragte");
        }
    }
}
