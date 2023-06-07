using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.RoleService.Dtos
{
	/// <summary>
	/// 角色导入模板 input
	/// </summary>
	[ExcelImporter(IsLabelingError = true)]
	public class RoleImport
	{
		/// <summary>
		/// 名称（唯一）
		/// </summary>
		[Required(ErrorMessage = "名称不能为空")]
		[MaxLength(50, ErrorMessage = "名称长度不能超过50")]
		[ImporterHeader(IsIgnore = false, AutoTrim = true, Name = "名称")]
		public string Name { get; set; }

		/// <summary>
		/// 角色编号（唯一）
		/// </summary>
		[Required(ErrorMessage = "角色编号不能为空")]
		[MaxLength(50, ErrorMessage = "角色编号长度不能超过50")]
		[RegularExpression(@"^[a-zA-Z0-9]{1,50}$", ErrorMessage = "角色编号必须是字母与数字的组合")]
		[ImporterHeader(IsIgnore = false, AutoTrim = true, Name = "角色编号", Description = "角色编号必须是字母与数字的组合")]
		public string RoleCode { get; set; }

		/// <summary>
		/// 是否启用（0=未启用，1=启用）
		/// </summary>
		[Required(ErrorMessage = "是否启用不能为空")]
		[ImporterHeader(IsIgnore = false, AutoTrim = true, Name = "是否启用", Description = "是否启用只能填写 是|否")]
		[ValueMapping("是", true)]
		[ValueMapping("否", false)]
		public bool IsEnable { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		[ImporterHeader(IsIgnore = false, AutoTrim = true, Name = "描述")]
		[MaxLength(1000, ErrorMessage = "描述长度不能超过1000")]
		public string Description { get; set; }
	}
}
