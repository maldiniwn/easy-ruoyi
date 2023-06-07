using EasyRuoyi.Core.Entities;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyRuoyi.Entities.Entities
{
	/// <summary>
	/// 用户角色关系
	/// </summary>
	[Comment("用户角色关系")]
	public class RoleUser : DEntityBase, IEntityTypeBuilder<RoleUser>
	{
		/// <summary>
		/// 用户主键
		/// </summary>
		[Comment("用户主键")]
		[Required(ErrorMessage = "用户主键不能为空")]
		public Guid UserInfoId { get; set; }

		/// <summary>
		/// 用户
		/// </summary>
		[ForeignKey(nameof(UserInfoId))]
		public virtual UserInfo UserInfo { get; set; }

		/// <summary>
		/// 角色主键
		/// </summary>
		[Comment("角色主键")]
		[Required(ErrorMessage = "角色主键不能为空")]
		public Guid RoleId { get; set; }

		/// <summary>
		/// 角色
		/// </summary>
		[ForeignKey(nameof(RoleId))]
		public virtual Role Role { get; set; }

		public void Configure(EntityTypeBuilder<RoleUser> entityBuilder, DbContext dbContext, Type dbContextLocator)
		{
			entityBuilder.HasOne(ru => ru.UserInfo).WithMany().OnDelete(DeleteBehavior.NoAction);

			entityBuilder.HasOne(ru => ru.Role).WithMany().OnDelete(DeleteBehavior.NoAction);
		}
	}
}
