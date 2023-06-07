using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Core.Attributes
{
	/// <summary>
	/// 验证Guid是否为 Guid.Empty
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class GuidRequiredAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value is Guid)
			{
				var id = (Guid)value;
				if (id != Guid.Empty)
				{
					return true;
				}
			}
			return false;
		}
	}
}
