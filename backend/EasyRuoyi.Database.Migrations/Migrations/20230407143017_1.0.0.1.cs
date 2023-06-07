using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRuoyi.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class _1001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouterName",
                table: "Menu",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "路由名称");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4647-842f-702c52ca50c5"),
                columns: new[] { "Path", "RouterName" },
                values: new object[] { "", "System" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466c-8fa3-68324e69dbca"),
                columns: new[] { "Path", "RouterName" },
                values: new object[] { "/system/user", "User" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466d-8aa7-61d152a82a08"),
                column: "RouterName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466d-8c11-4841922dd430"),
                columns: new[] { "RouterName", "Sort" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466d-8f69-e9af248a7e9a"),
                columns: new[] { "RouterName", "Sort" },
                values: new object[] { null, 3 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466e-8246-642217ecf1fe"),
                columns: new[] { "RouterName", "Sort" },
                values: new object[] { null, 4 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466e-8499-700ce0a16017"),
                columns: new[] { "Path", "RouterName", "Sort" },
                values: new object[] { "/system/role", "Role", 2 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466e-87b8-b44f3652ddc8"),
                column: "RouterName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466e-8957-bc339ab2fb1c"),
                columns: new[] { "RouterName", "Sort" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466f-8af0-850d768cf158"),
                columns: new[] { "RouterName", "Sort" },
                values: new object[] { null, 3 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466f-8c16-266c6e0fb639"),
                columns: new[] { "RouterName", "Sort" },
                values: new object[] { null, 4 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466f-8f97-cc651bdb79e5"),
                columns: new[] { "Path", "RouterName", "Sort" },
                values: new object[] { "/system/menu", "Menu", 3 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4670-8139-e1682f10bae7"),
                column: "RouterName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4670-8351-1628fbce7366"),
                columns: new[] { "RouterName", "Sort" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4670-85aa-f81d31913533"),
                columns: new[] { "RouterName", "Sort" },
                values: new object[] { null, 3 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4670-8e03-f77d69f154a8"),
                columns: new[] { "RouterName", "Sort" },
                values: new object[] { null, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouterName",
                table: "Menu");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4647-842f-702c52ca50c5"),
                column: "Path",
                value: "/system");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466c-8fa3-68324e69dbca"),
                column: "Path",
                value: "user");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466d-8c11-4841922dd430"),
                column: "Sort",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466d-8f69-e9af248a7e9a"),
                column: "Sort",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466e-8246-642217ecf1fe"),
                column: "Sort",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466e-8499-700ce0a16017"),
                columns: new[] { "Path", "Sort" },
                values: new object[] { "role", 1 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466e-8957-bc339ab2fb1c"),
                column: "Sort",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466f-8af0-850d768cf158"),
                column: "Sort",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466f-8c16-266c6e0fb639"),
                column: "Sort",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-466f-8f97-cc651bdb79e5"),
                columns: new[] { "Path", "Sort" },
                values: new object[] { "menu", 1 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4670-8351-1628fbce7366"),
                column: "Sort",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4670-85aa-f81d31913533"),
                column: "Sort",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("08daa9c2-cf08-4670-8e03-f77d69f154a8"),
                column: "Sort",
                value: 1);
        }
    }
}
