using EasyRuoyi.Core.Enums;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;

namespace EasyRuoyi.Application.Services.UserInfoService.Dtos
{
	/// <summary>
	/// 用户导入模板 input
	/// </summary>
	[ExcelImporter(IsLabelingError = true)]
	public class UserInfoImport
	{
		/// <summary>
		/// 用户名（唯一）
		/// </summary>
		[Required(ErrorMessage = "用户名不能为空")]
		[MaxLength(50)]
		[ImporterHeader(IsIgnore = false, AutoTrim = true, Name = "用户名", Description = "用户名要求唯一")]
		public string UserName { get; set; }

		/// <summary>
		/// 姓名
		/// </summary>
		[Required(ErrorMessage = "姓名不能为空")]
		[MaxLength(50)]
		[ImporterHeader(IsIgnore = false, AutoTrim = true, Name = "姓名")]
		public string Name { get; set; }

		/// <summary>
		/// 性别
		/// </summary>
		[Required(ErrorMessage = "性别不能为空")]
		[ImporterHeader(IsIgnore = false, AutoTrim = true, Name = "性别")]
		[ValueMapping("未知", EnumGender.Unknow)]
		[ValueMapping("男", EnumGender.Male)]
		[ValueMapping("女", EnumGender.Female)]
		public EnumGender EnumGender { get; set; }

		/// <summary>
		/// 手机号
		/// </summary>
		[RegularExpression(@"^1\d{10}$", ErrorMessage = "手机号格式错误！")]
		[ImporterHeader(IsIgnore = false, AutoTrim = true, Name = "手机号")]
		public string Tel { get; set; }

		/// <summary>
		/// 身份证
		/// </summary>
		[RegularExpression(@"(^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$)|(^[1-9]\d{5}\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{2}$)", ErrorMessage = "身份证号格式错误")]
		[ImporterHeader(IsIgnore = false, AutoTrim = true, Name = "身份证", Description = "身份证要求唯一")]
		public string SID { get; set; }

		/// <summary>
		/// 出生日期
		/// </summary>
		[ImporterHeader(IsIgnore = false, AutoTrim = true, Name = "出生日期", Description = "请输入日期格式")]
		public DateTime? BornDate { get; set; }
	}
}
