using EasyRuoyi.Core.Attributes;
using EasyRuoyi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.UserCenterService.Dtos
{
	/// <summary>
	/// 修改基本资料 input
	/// </summary>
	public class EditEmpInput
	{
		/// <summary>
		/// Id
		/// </summary>
		[GuidRequired(ErrorMessage = "Id不能为空")]
		public Guid Id { get; set; }

		/// <summary>
		/// 姓名
		/// </summary>
		[Required(ErrorMessage = "姓名不能为空")]
		public string Name { get; set; }

		/// <summary>
		/// 性别
		/// </summary>
		[Required(ErrorMessage = "性别不能为空")]
		public EnumGender EnumGender { get; set; }

		/// <summary>
		/// 手机号
		/// </summary>
		[RegularExpression(@"^1\d{10}$", ErrorMessage = "手机号格式错误！")]
		public string Tel { get; set; }

		/// <summary>
		/// 身份证
		/// </summary>
		[RegularExpression(@"(^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$)|(^[1-9]\d{5}\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{2}$)", ErrorMessage = "身份证号格式错误")]
		public string SID { get; set; }

		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime? BornDate { get; set; }
	}
}
