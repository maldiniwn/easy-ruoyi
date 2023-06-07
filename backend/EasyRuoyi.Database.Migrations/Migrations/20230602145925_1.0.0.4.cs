using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRuoyi.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class _1004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "UserInfo",
                type: "uniqueidentifier",
                nullable: false,
                comment: "员工Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "密码");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SysFile",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                comment: "存储路径",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "存储路径");

            migrationBuilder.AddColumn<string>(
                name: "HeadUrl",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                comment: "头像");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"),
                column: "HeadUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadUrl",
                table: "Employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "UserInfo",
                type: "uniqueidentifier",
                nullable: false,
                comment: "密码",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "员工Id");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SysFile",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "存储路径",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true,
                oldComment: "存储路径");
        }
    }
}
