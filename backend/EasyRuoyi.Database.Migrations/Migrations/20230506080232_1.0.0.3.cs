using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRuoyi.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class _1003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "UserInfo",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "UserInfo",
                type: "datetimeoffset",
                nullable: false,
                comment: "修改时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "UserInfo",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "SysFile",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "SysFile",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "SysFile",
                type: "datetimeoffset",
                nullable: false,
                comment: "修改时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "SysFile",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "SysFile",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "RoleUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "RoleUser",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "RoleUser",
                type: "datetimeoffset",
                nullable: false,
                comment: "修改时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "RoleUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "RoleUser",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "RoleMenu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "RoleMenu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "RoleMenu",
                type: "datetimeoffset",
                nullable: false,
                comment: "修改时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "RoleMenu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "RoleMenu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "Role",
                type: "datetimeoffset",
                nullable: false,
                comment: "修改时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "Menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "Menu",
                type: "datetimeoffset",
                nullable: false,
                comment: "修改时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "Menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "Employee",
                type: "datetimeoffset",
                nullable: false,
                comment: "修改时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Employee",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "手机号");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"),
                column: "Tel",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "UserInfo",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改人Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "UserInfo",
                type: "datetimeoffset",
                nullable: false,
                comment: "更新时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "修改时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "UserInfo",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建人Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "SysFile",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "SysFile",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改人Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "SysFile",
                type: "datetimeoffset",
                nullable: false,
                comment: "更新时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "修改时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "SysFile",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "SysFile",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建人Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "RoleUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "RoleUser",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改人Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "RoleUser",
                type: "datetimeoffset",
                nullable: false,
                comment: "更新时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "修改时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "RoleUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "RoleUser",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建人Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "RoleMenu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "RoleMenu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改人Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "RoleMenu",
                type: "datetimeoffset",
                nullable: false,
                comment: "更新时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "修改时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "RoleMenu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "RoleMenu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建人Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改人Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "Role",
                type: "datetimeoffset",
                nullable: false,
                comment: "更新时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "修改时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建人Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "Menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改人Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "Menu",
                type: "datetimeoffset",
                nullable: false,
                comment: "更新时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "修改时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "Menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建人Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改人Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedTime",
                table: "Employee",
                type: "datetimeoffset",
                nullable: false,
                comment: "更新时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "修改时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建人Id");
        }
    }
}
