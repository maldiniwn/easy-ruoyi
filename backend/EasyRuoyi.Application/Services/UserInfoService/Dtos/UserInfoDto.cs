using EasyRuoyi.Core.Enums;
using Magicodes.ExporterAndImporter.Core;
using System.Text.Json.Serialization;

namespace EasyRuoyi.Application.Services.UserInfoService.Dtos
{
	/// <summary>
	/// 用户 dto
	/// </summary>
	public class UserInfoDto
	{
		/// <summary>
		/// Id
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public Guid Id { get; set; }

		/// <summary>
		/// 用户名（唯一）
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "用户名")]
		public string UserName { get; set; }

		/// <summary>
		/// 员工
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public Guid EmployeeId { get; set; }

		/// <summary>
		/// 姓名
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "姓名")]
		public string Name { get; set; }

		/// <summary>
		/// 性别
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public EnumGender EnumGender { get; set; }

		/// <summary>
		/// 性别
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "性别")]
		public string EnumGenderStr { get; set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public bool IsEnable { get; set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "是否启用")]
		public string IsEnableStr => this.IsEnable ? "启用" : "禁用";

		/// <summary>
		/// 手机号
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public string Tel { get; set; }

		/// <summary>
		/// 身份证
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public string SID { get; set; }

		/// <summary>
		/// 出生日期
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public DateTime? BornDate { get; set; }

		/// <summary>
		/// 出生日期
		/// </summary>
		[ExporterHeader(IsIgnore = false, DisplayName = "出生日期")]
		public string BornDateStr => this.BornDate?.ToString("yyyy-MM-dd");

		/// <summary>
		/// 头像。
		/// 格式："[{id:'',name:'',length:'',url:''},{id:'',name:'',length:'',url:''}]"
		/// </summary>
		[ExporterHeader(IsIgnore = true)]
		public string HeadUrl { get; set; }

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
