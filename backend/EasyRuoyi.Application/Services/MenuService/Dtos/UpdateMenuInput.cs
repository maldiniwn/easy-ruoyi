using EasyRuoyi.Core.Attributes;
using EasyRuoyi.Entities.Enums;

namespace EasyRuoyi.Application.Services.MenuService.Dtos
{
	public class UpdateMenuInput
	{
		/// <summary>
		/// Id
		/// </summary>
		[GuidRequired(ErrorMessage = "Id不能为空")]
		public Guid Id { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		[Required(ErrorMessage = "名称不能为空")]
		public string Name { get; set; }

		/// <summary>
		/// 父级
		/// </summary>
		public Guid? PId { get; set; }

		/// <summary>
		/// 全路径
		/// </summary>
		public string FullPath { get; set; }

		/// <summary>
		/// 菜单类型
		/// </summary>
		[Required(ErrorMessage = "菜单类型不能为空")]
		public EnumMenuType EnumMenuType { get; set; }

		/// <summary>
		/// 权限标识
		/// </summary>
		public string PermissionCode { get; set; }

		/// <summary>
		/// 菜单图标 
		///</summary>
		public string MenuIcon { get; set; }

		/// <summary>
		/// 路由名称
		/// </summary>
		public string RouterName { get; set; }

		/// <summary>
		/// 路由地址 
		///</summary>
		public string Path { get; set; }

		/// <summary>
		/// 组件路径 
		///</summary>
		public string Component { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		[Required(ErrorMessage = "排序不能为空")]
		public int Sort { get; set; }

		/// <summary>
		/// 是否缓存 
		///</summary>
		[Required(ErrorMessage = "是否缓存不能为空")]
		public bool IsCache { get; set; }

		/// <summary>
		/// 是否显示 
		///</summary>
		[Required(ErrorMessage = "是否显示不能为空")]
		public bool IsShow { get; set; }

		/// <summary>
		/// 是否启用（0=未启用，1=启用）
		/// </summary>
		[Required(ErrorMessage = "是否启用不能为空")]
		public bool IsEnable { get; set; }
	}
}
