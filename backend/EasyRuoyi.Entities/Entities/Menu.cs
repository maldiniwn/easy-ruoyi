using EasyRuoyi.Core.Entities;
using EasyRuoyi.Core.Enums;
using EasyRuoyi.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyRuoyi.Entities.Entities
{
	/// <summary>
	/// 菜单
	/// </summary>
	[Comment("菜单")]
	public class Menu : DEntityBase
	{
		/// <summary>
		/// 名称
		/// </summary>
		[Comment("名称")]
		[Required(ErrorMessage = "名称不能为空")]
		[MaxLength(50)]
		public string Name { get; set; }

		/// <summary>
		/// 父级
		/// </summary>
		[Comment("父级")]
		public Guid? PId { get; set; }

		/// <summary>
		/// 全路径
		/// </summary>
		[Comment("全路径")]
		[Required(ErrorMessage = "全路径不能为空")]
		public string FullPath { get; set; }

		/// <summary>
		/// 菜单类型
		/// </summary>
		[Comment("菜单类型")]
		[Required(ErrorMessage = "菜单类型不能为空")]
		public EnumMenuType EnumMenuType { get; set; }

		/// <summary>
		/// 权限标识
		/// </summary>
		[Comment("权限标识")]
		[MaxLength(128)]
		[Column(TypeName = "varchar")]
		public string PermissionCode { get; set; }

		/// <summary>
		/// 菜单图标 
		///</summary>
		[Comment("菜单图标")]
		[MaxLength(50)]
		[Column(TypeName = "varchar")]
		public string MenuIcon { get; set; }

		/// <summary>
		/// 路由名称
		/// </summary>
		[Comment("路由名称")]
		[MaxLength(50)]
		[Column(TypeName = "varchar")]
		public string RouterName { get; set; }

		/// <summary>
		/// 路由地址 
		///</summary>
		[Comment("路由地址")]
		[MaxLength(128)]
		[Column(TypeName = "varchar")]
		public string Path { get; set; }

		///// <summary>
		///// 路由参数 
		/////</summary>
		//[Comment("路由参数")]
		//[MaxLength(256)]
		//public string RouterParams { get; set; }

		/// <summary>
		/// 组件路径 
		///</summary>
		[Comment("组件路径")]
		[MaxLength(128)]
		[Column(TypeName = "varchar")]
		public string Component { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		[Comment("排序")]
		[Required(ErrorMessage = "排序不能为空")]
		public int Sort { get; set; }

		///// <summary>
		///// 是否为外部链接 
		/////</summary>
		//[Comment("是否为外部链接")]
		//[Required(ErrorMessage = "是否为外部链接不能为空")]
		//public bool IsLink { get; set; }

		/// <summary>
		/// 是否缓存 
		///</summary>
		[Comment("是否缓存")]
		[Required(ErrorMessage = "是否缓存不能为空")]
		public bool IsCache { get; set; }

		/// <summary>
		/// 是否显示 
		///</summary>
		[Comment("是否显示")]
		[Required(ErrorMessage = "是否显示不能为空")]
		public bool IsShow { get; set; }

		/// <summary>
		/// 是否启用（0=未启用，1=启用）
		/// </summary>
		[Comment("是否启用")]
		[Required(ErrorMessage = "是否启用不能为空")]
		public bool IsEnable { get; set; }
	}
}
