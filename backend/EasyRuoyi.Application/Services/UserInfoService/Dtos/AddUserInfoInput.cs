using EasyRuoyi.Core.Enums;

namespace EasyRuoyi.Application.Services.UserInfoService.Dtos
{
	/// <summary>
	/// 新增用户 input
	/// </summary>
	public class AddUserInfoInput
	{
		/// <summary>
		/// 用户名
		/// </summary>
		[Required(ErrorMessage = "用户名不能为空")]
		public string UserName { get; set; }

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

		/// <summary>
		/// 头像。
		/// 格式："[{id:'',name:'',length:'',url:''},{id:'',name:'',length:'',url:''}]"
		/// </summary>
		public string HeadUrl { get; set; }
	}
}
