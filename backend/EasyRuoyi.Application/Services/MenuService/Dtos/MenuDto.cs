using EasyRuoyi.Entities.Enums;
using Magicodes.ExporterAndImporter.Core;
using System.Text.Json.Serialization;

namespace EasyRuoyi.Application.Services.MenuService.Dtos
{
	/// <summary>
	/// 菜单 Dto
	/// </summary>
	public class MenuDto
	{
		/// <summary>
		/// Id
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public Guid Id { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "菜单名称")]
		public string Name { get; set; }

		/// <summary>
		/// 父级
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public Guid? PId { get; set; }

		/// <summary>
		/// 父级
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public string PName { get; set; }

		/// <summary>
		/// 全路径
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public string FullPath { get; set; }

		/// <summary>
		/// 菜单类型
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public EnumMenuType EnumMenuType { get; set; }

		/// <summary>
		/// 菜单类型
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public string EnumMenuTypeStr { get; set; }

		/// <summary>
		/// 权限标识
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "权限标识")]
		public string PermissionCode { get; set; }

		/// <summary>
		/// 菜单图标 
		///</summary>
		[ExporterHeader(IsIgnore = true)]
		public string MenuIcon { get; set; }

		/// <summary>
		/// 路由名称
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public string RouterName { get; set; }

		/// <summary>
		/// 路由地址 
		///</summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "路由地址")]
		public string Path { get; set; }

		/// <summary>
		/// 组件路径 
		///</summary>
		[ExporterHeader(IsIgnore = true)]
		public string Component { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public int Sort { get; set; }

		/// <summary>
		/// 是否缓存 
		///</summary>
		[ExporterHeader(IsIgnore = true)]
		public bool IsCache { get; set; }

		/// <summary>
		/// 是否缓存 
		///</summary>
		[ExporterHeader(IsIgnore = true)]
		public string IsCacheStr => this.IsCache ? "是" : "否";

		/// <summary>
		/// 是否显示 
		///</summary>
		[ExporterHeader(IsIgnore = true)]
		public bool IsShow { get; set; }

		/// <summary>
		/// 是否显示 
		///</summary>
		[ExporterHeader(IsIgnore = true)]
		public string IsShowStr => this.IsShow ? "是" : "否";

		/// <summary>
		/// 是否启用（0=未启用，1=启用）
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public bool IsEnable { get; set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "菜单状态")]
		public string IsEnableStr => this.IsEnable ? "启用" : "禁用";

		/// <summary>
		/// 创建人Id
		/// </summary>
		[JsonIgnore]
		[ExporterHeader(IsIgnore = true)]
		public Guid? CreatedUserId { get; set; }

		/// <summary>
		/// 创建人名称
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "创建人")]
		public string CreatedUserName { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public DateTimeOffset CreatedTime { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "创建时间")]
		public string CreatedTimeStr => this.CreatedTime.ToString("yyyy-MM-dd HH:mm:ss");

		/// <summary>
		/// 修改人Id
		/// </summary>
		[JsonIgnore]
		[ExporterHeader(IsIgnore = true)]
		public Guid? UpdatedUserId { get; set; }

		/// <summary>
		/// 修改人名称
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "修改人")]
		public string UpdatedUserName { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public DateTimeOffset UpdatedTime { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "修改时间")]
		public string UpdateTimeStr => this.UpdatedTime.ToString("yyyy-MM-dd HH:mm:ss");

		/// <summary>
		/// 软删除
		/// </summary>
		[JsonIgnore]
		[ExporterHeader(IsIgnore = true)]
		public bool IsDeleted { get; set; } = false;

		/// <summary>
		/// 软删除时间
		/// </summary>
		[JsonIgnore]
		[ExporterHeader(IsIgnore = true)]
		public DateTimeOffset? DeletedTime { get; set; }
	}
}
