using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyRuoyi.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "姓名"),
                    EnumGender = table.Column<int>(type: "int", nullable: false, comment: "性别"),
                    SID = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: true, comment: "身份证"),
                    BornDate = table.Column<DateTime>(type: "date", nullable: true, comment: "出生日期"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "创建者名称"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "修改者名称"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "更新时间"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记"),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "软删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                },
                comment: "员工");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "名称"),
                    PId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "父级"),
                    FullPath = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "全路径"),
                    EnumMenuType = table.Column<int>(type: "int", nullable: false, comment: "菜单类型"),
                    PermissionCode = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "权限标识"),
                    MenuIcon = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "菜单图标"),
                    Path = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "路由地址"),
                    Component = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "组件路径"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    IsCache = table.Column<bool>(type: "bit", nullable: false, comment: "是否缓存"),
                    IsShow = table.Column<bool>(type: "bit", nullable: false, comment: "是否显示"),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "创建者名称"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "修改者名称"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "更新时间"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记"),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "软删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                },
                comment: "菜单");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "名称"),
                    RoleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "角色编号"),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用（0=未启用，1=启用）"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "描述"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "创建者名称"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "修改者名称"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "更新时间"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记"),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "软删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                },
                comment: "角色");

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "用户名"),
                    Password = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "密码"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "密码"),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用（0=未启用，1=启用）"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "创建者名称"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "修改者名称"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "更新时间"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记"),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "软删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfo_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                },
                comment: "用户");

            migrationBuilder.CreateTable(
                name: "RoleMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id"),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "菜单主键"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "角色主键"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "创建者名称"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "修改者名称"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "更新时间"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记"),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "软删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMenu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleMenu_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                },
                comment: "菜单角色关系");

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id"),
                    UserInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "用户主键"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "角色主键"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "创建者名称"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "修改者名称"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "更新时间"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记"),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "软删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleUser_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleUser_UserInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id");
                },
                comment: "用户角色关系");

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "BornDate", "CreatedTime", "CreatedUserId", "CreatedUserName", "DeletedTime", "EnumGender", "IsDeleted", "Name", "SID", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[] { new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 1, false, "超级管理员", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Component", "CreatedTime", "CreatedUserId", "CreatedUserName", "DeletedTime", "EnumMenuType", "FullPath", "IsCache", "IsDeleted", "IsEnable", "IsShow", "MenuIcon", "Name", "PId", "Path", "PermissionCode", "Sort", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[,]
                {
                    { new Guid("08daa9c2-cf08-4647-842f-702c52ca50c5"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 0, "系统管理/", false, false, true, true, "system", "系统管理", null, "/system", "", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466c-8fa3-68324e69dbca"), "system/user/index", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 1, "系统管理/用户管理/", false, false, true, true, "user", "用户管理", new Guid("08daa9c2-cf08-4647-842f-702c52ca50c5"), "user", "system:user:list", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466d-8aa7-61d152a82a08"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/用户管理/用户查询/", false, false, true, true, "", "用户查询", new Guid("08daa9c2-cf08-466c-8fa3-68324e69dbca"), "", "system:user:query", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466d-8c11-4841922dd430"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/用户管理/用户新增/", false, false, true, true, "", "用户新增", new Guid("08daa9c2-cf08-466c-8fa3-68324e69dbca"), "", "system:user:add", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466d-8f69-e9af248a7e9a"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/用户管理/用户修改/", false, false, true, true, "", "用户修改", new Guid("08daa9c2-cf08-466c-8fa3-68324e69dbca"), "", "system:user:edit", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466e-8246-642217ecf1fe"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/用户管理/用户删除/", false, false, true, true, "", "用户删除", new Guid("08daa9c2-cf08-466c-8fa3-68324e69dbca"), "", "system:user:remove", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466e-8499-700ce0a16017"), "system/role/index", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 1, "系统管理/角色管理/", false, false, true, true, "peoples", "角色管理", new Guid("08daa9c2-cf08-4647-842f-702c52ca50c5"), "role", "system:role:list", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466e-87b8-b44f3652ddc8"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/角色管理/角色查询/", false, false, true, true, "", "角色查询", new Guid("08daa9c2-cf08-466e-8499-700ce0a16017"), "", "system:role:query", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466e-8957-bc339ab2fb1c"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/角色管理/角色新增/", false, false, true, true, "", "角色新增", new Guid("08daa9c2-cf08-466e-8499-700ce0a16017"), "", "system:role:add", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466f-8af0-850d768cf158"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/角色管理/角色修改/", false, false, true, true, "", "角色修改", new Guid("08daa9c2-cf08-466e-8499-700ce0a16017"), "", "system:role:edit", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466f-8c16-266c6e0fb639"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/角色管理/角色删除/", false, false, true, true, "", "角色删除", new Guid("08daa9c2-cf08-466e-8499-700ce0a16017"), "", "system:role:remove", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-466f-8f97-cc651bdb79e5"), "system/menu/index", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 1, "系统管理/菜单管理/", false, false, true, true, "tree-table", "菜单管理", new Guid("08daa9c2-cf08-4647-842f-702c52ca50c5"), "menu", "system:menu:list", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-4670-8139-e1682f10bae7"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/菜单管理/菜单查询/", false, false, true, true, "", "菜单查询", new Guid("08daa9c2-cf08-466f-8f97-cc651bdb79e5"), "", "system:menu:query", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-4670-8351-1628fbce7366"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/菜单管理/菜单新增/", false, false, true, true, "", "菜单新增", new Guid("08daa9c2-cf08-466f-8f97-cc651bdb79e5"), "", "system:menu:add", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-4670-85aa-f81d31913533"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/菜单管理/菜单修改/", false, false, true, true, "", "菜单修改", new Guid("08daa9c2-cf08-466f-8f97-cc651bdb79e5"), "", "system:menu:edit", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" },
                    { new Guid("08daa9c2-cf08-4670-8e03-f77d69f154a8"), "", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, 2, "系统管理/菜单管理/菜单删除/", false, false, true, true, "", "菜单删除", new Guid("08daa9c2-cf08-466f-8f97-cc651bdb79e5"), "", "system:menu:remove", 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "CreatedUserName", "DeletedTime", "Description", "IsDeleted", "IsEnable", "Name", "RoleCode", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[] { new Guid("0df02f30-9cdb-5cb4-970a-316e5212bb34"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, "超级管理员角色，不能修改、删除", false, true, "超级管理员", "Admin", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "CreatedUserName", "DeletedTime", "EmployeeId", "IsDeleted", "IsEnable", "Password", "UpdatedTime", "UpdatedUserId", "UpdatedUserName", "UserName" },
                values: new object[] { new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", null, new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), false, true, "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), new Guid("292f2321-577a-a7a5-4389-4a0e4a801fc3"), "超级管理员", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_MenuId",
                table: "RoleMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_RoleId",
                table: "RoleMenu",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_RoleId",
                table: "RoleUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UserInfoId",
                table: "RoleUser",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_EmployeeId",
                table: "UserInfo",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_UserName",
                table: "UserInfo",
                column: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleMenu");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
