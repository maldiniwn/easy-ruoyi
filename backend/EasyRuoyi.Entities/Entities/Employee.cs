using EasyRuoyi.Core.Entities;
using EasyRuoyi.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyRuoyi.Entities.Entities
{
	/// <summary>
	/// 员工
	/// </summary>
	[Comment("员工")]
	public class Employee : DEntityBase
	{
		/// <summary>
		/// 姓名
		/// </summary>
		[Comment("姓名")]
		[Required(ErrorMessage = "姓名不能为空")]
		[MaxLength(50)]
		public string Name { get; set; }

		/// <summary>
		/// 性别
		/// </summary>
		[Comment("性别")]
		[Required(ErrorMessage = "性别不能为空")]
		[DefaultValue(EnumGender.Unknow)]
		public EnumGender EnumGender { get; set; }

		/// <summary>
		/// 手机号
		/// </summary>
		[Comment("手机号")]
		[MaxLength(20)]
		[Column(TypeName = "varchar")]
		[RegularExpression(@"^1\d{10}$", ErrorMessage = "手机号格式错误！")]
		public string Tel { get; set; }

		/// <summary>
		/// 身份证
		/// </summary>
		[Comment("身份证")]
		[MaxLength(18)]
		[Column(TypeName = "varchar")]
		[RegularExpression(@"(^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$)|(^[1-9]\d{5}\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{2}$)", ErrorMessage = "身份证号格式错误")]
		public string SID { get; set; }

		/// <summary>
		/// 出生日期
		/// </summary>
		[Comment("出生日期")]
		[Column(TypeName = "date")]
		public DateTime? BornDate { get; set; }

		/// <summary>
		/// 头像。
		/// 格式：["id1","id2"]
		/// </summary>
		[Comment("头像")]
		public string HeadUrl { get; set; }
	}
}
