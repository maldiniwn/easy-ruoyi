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
	/// 菜单角色关系
	/// </summary>
	[Comment("菜单角色关系")]
	public class RoleMenu : DEntityBase, IEntityTypeBuilder<RoleMenu>
	{
		/// <summary>
		/// 菜单主键
		/// </summary>
		[Comment("菜单主键")]
		[Required(ErrorMessage = "菜单主键不能为空")]
		public Guid MenuId { get; set; }

		/// <summary>
		/// 菜单
		/// </summary>
		[ForeignKey(nameof(MenuId))]
		public virtual Menu Menu { get; set; }

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

		public void Configure(EntityTypeBuilder<RoleMenu> entityBuilder, DbContext dbContext, Type dbContextLocator)
		{
			entityBuilder.HasOne(rm => rm.Menu).WithMany().OnDelete(DeleteBehavior.NoAction);

			entityBuilder.HasOne(rm => rm.Role).WithMany().OnDelete(DeleteBehavior.NoAction);
		}
	}
}
