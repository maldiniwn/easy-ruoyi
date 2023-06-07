﻿// <auto-generated />
using System;
using FileServer.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FileServer.Database.Migrations.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20230524075813_InitDatabase")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FileServer.Entities.Entities.SysFile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("创建人Id");

                    b.Property<string>("CreatedUserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("创建人名称");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("软删除时间");

                    b.Property<string>("FileObjectName")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)")
                        .HasComment("存储文件名称");

                    b.Property<string>("FileOriginName")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)")
                        .HasComment("原始文件名称");

                    b.Property<string>("FilePath")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)")
                        .HasComment("存储路径");

                    b.Property<string>("FileSHA256Hash")
                        .HasMaxLength(64)
                        .HasColumnType("varchar")
                        .HasComment("文件SHA256哈希");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint")
                        .HasComment("文件大小byte");

                    b.Property<string>("FileSuffix")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("文件后缀");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("软删除标记");

                    b.Property<DateTimeOffset>("UpdatedTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("修改时间");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("修改人Id");

                    b.Property<string>("UpdatedUserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("修改人名称");

                    b.HasKey("Id");

                    b.ToTable("SysFile", t =>
                        {
                            t.HasComment("文件信息");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
