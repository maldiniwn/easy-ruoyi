using EasyRuoyi.Core.Entities;
using Furion;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyRuoyi.Entities.Entities
{
	/// <summary>
	/// 角色
	/// </summary>
	[Comment("角色")]
	//[Index(nameof(Name), IsUnique = true)]
	//[Index(nameof(RoleCode), IsUnique = true)]
	public class Role : DEntityBase
	{
		/// <summary>
		/// 超级管理员角色
		/// </summary>
		public static readonly Guid SuperRoleId = Guid.Parse(App.Configuration["SeedData:Role:Id"]);

		/// <summary>
		/// 名称（唯一）
		/// </summary>
		[Comment("名称")]
		[Required(ErrorMessage = "名称不能为空")]
		[MaxLength(50)]
		public string Name { get; set; }

		/// <summary>
		/// 角色编号（唯一）
		/// </summary>
		[Comment("角色编号")]
		[Required(ErrorMessage = "角色编号不能为空")]
		[MaxLength(50)]
		public string RoleCode { get; set; }

		/// <summary>
		/// 是否启用（0=未启用，1=启用）
		/// </summary>
		[Comment("是否启用（0=未启用，1=启用）")]
		[Required(ErrorMessage = "是否启用不能为空")]
		[DefaultValue(true)]
		public bool IsEnable { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		[Comment("描述")]
		public string Description { get; set; }
	}
}
