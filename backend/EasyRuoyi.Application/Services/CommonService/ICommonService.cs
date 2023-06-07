using EasyRuoyi.Core.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.CommonService
{
	/// <summary>
	/// 通用接口
	/// </summary>
	public interface ICommonService
	{
		/// <summary>
		/// 获取枚举成员列表
		/// </summary>
		/// <param name="enumTypeName">枚举类型名称</param>
		/// <returns></returns>
		IList<SelectListModel<int>> GetEnums(string enumTypeName);
	}
}
