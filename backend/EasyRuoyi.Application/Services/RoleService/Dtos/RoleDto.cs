using Magicodes.ExporterAndImporter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleService.Dtos
{
	/// <summary>
	/// 角色Dto
	/// </summary>
	public class RoleDto
	{
		/// <summary>
		/// Id
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public Guid Id { get; set; }

		/// <summary>
		/// 名称（唯一）
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "角色名称")]
		public string Name { get; set; }

		/// <summary>
		/// 角色编号（唯一）
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "角色编号")]
		public string RoleCode { get; set; }

		/// <summary>
		/// 是否启用（0=未启用，1=启用）
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public bool IsEnable { get; set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "是否启用")]
		public string IsEnableStr => this.IsEnable ? "是" : "否";

		/// <summary>
		/// 描述
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "描述")]
		public string Description { get; set; }

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
