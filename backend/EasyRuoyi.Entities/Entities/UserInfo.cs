using EasyRuoyi.Core.Entities;
using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyRuoyi.Entities.Entities
{
	/// <summary>
	/// 用户
	/// </summary>
	[Comment("用户")]
	[Index(nameof(UserName))]
	public class UserInfo : DEntityBase, IEntityTypeBuilder<UserInfo>
	{
		/// <summary>
		/// 超级管理员用户
		/// </summary>
		public static readonly Guid SuperAdminId = Guid.Parse(App.Configuration["SeedData:UserInfo:Id"]);

		/// <summary>
		/// 用户名（唯一）
		/// </summary>
		[Comment("用户名")]
		[Required(ErrorMessage = "用户名不能为空")]
		[Column(TypeName = "varchar")]
		[MaxLength(50)]
		public string UserName { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		[Comment("密码")]
		[Required(ErrorMessage = "密码不能为空")]
		[Column(TypeName = "varchar")]
		[MaxLength(64)]
		public string Password { get; set; }

		/// <summary>
		/// 员工
		/// </summary>
		[Comment("员工Id")]
		[Required(ErrorMessage = "员工Id不能为空")]
		public Guid EmployeeId { get; set; }

		/// <summary>
		/// 员工
		/// </summary>
		[ForeignKey(nameof(EmployeeId))]
		public virtual Employee Employee { get; set; }

		/// <summary>
		/// 是否启用（0=未启用，1=启用）
		/// </summary>
		[Comment("是否启用（0=未启用，1=启用）")]
		[Required(ErrorMessage = "是否启用不能为空")]
		[DefaultValue(true)]
		public bool IsEnable { get; set; }

		public void Configure(EntityTypeBuilder<UserInfo> entityBuilder, DbContext dbContext, Type dbContextLocator)
		{
			entityBuilder.HasOne(e => e.Employee).WithOne().OnDelete(DeleteBehavior.NoAction);
		}
	}
}
