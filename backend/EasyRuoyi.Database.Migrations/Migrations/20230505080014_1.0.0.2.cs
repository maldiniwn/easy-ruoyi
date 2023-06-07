using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRuoyi.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class _1002 : Migration
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
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "UserInfo",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "修改者Id");

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
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "UserInfo",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "创建者Id");

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
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "RoleUser",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "修改者Id");

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
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "RoleUser",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "创建者Id");

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
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "RoleMenu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "修改者Id");

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
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "RoleMenu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "创建者Id");

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
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "修改者Id");

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
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "创建者Id");

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
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "修改者Id");

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
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "创建者Id");

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
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true,
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "修改者Id");

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
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "创建者Id");

            migrationBuilder.CreateTable(
                name: "SysFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id"),
                    FileOriginName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "原始文件名称"),
                    FileSuffix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "文件后缀"),
                    FileSizeKb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "文件大小kb"),
                    FileObjectName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "存储文件名称"),
                    FilePath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "存储路径"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "创建者名称"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "修改者名称"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "更新时间"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记"),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "软删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysFile", x => x.Id);
                },
                comment: "文件信息");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4647-842f-702c52ca50c5"),
                column: "Path",
                value: "/system");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0df02f30-9cdb-5cb4-970a-316e5212bb34"),
                column: "RoleCode",
                value: "SuperAdmin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysFile");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "UserInfo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "UserInfo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "RoleUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "RoleUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "RoleUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "RoleUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "RoleMenu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "RoleMenu",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "RoleMenu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "RoleMenu",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "Menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "Menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedUserName",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "修改者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "修改者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedUserId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "修改者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "修改者Id");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "创建者名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建者名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "创建者Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建者Id");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4647-842f-702c52ca50c5"),
                column: "Path",
                value: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0df02f30-9cdb-5cb4-970a-316e5212bb34"),
                column: "RoleCode",
                value: "Admin");
        }
    }
}
