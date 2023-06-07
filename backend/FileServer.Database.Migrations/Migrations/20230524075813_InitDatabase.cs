using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileServer.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id"),
                    FileOriginName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "原始文件名称"),
                    FileSuffix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "文件后缀"),
                    FileSize = table.Column<long>(type: "bigint", nullable: false, comment: "文件大小byte"),
                    FileSHA256Hash = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "文件SHA256哈希"),
                    FileObjectName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "存储文件名称"),
                    FilePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true, comment: "存储路径"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "创建人Id"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "创建人名称"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "修改人Id"),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "修改人名称"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "修改时间"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记"),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "软删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysFile", x => x.Id);
                },
                comment: "文件信息");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysFile");
        }
    }
}
