using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Application.Services.CommonService
{
	/// <summary>
	/// 通用服务
	/// </summary>
	[ApiDescriptionSettings("系统管理", Name = "Common", Order = 1)]
	[Route("common")]
	public class CommonService : ICommonService, IDynamicApiController, ITransient
	{
		public CommonService()
		{

		}

		/// <summary>
		/// 获取枚举成员列表
		/// </summary>
		/// <param name="enumTypeName">枚举类型名称</param>
		/// <returns></returns>
		[HttpGet("getenums")]
		public IList<SelectListModel<int>> GetEnums(string enumTypeName)
		{
			var results = EnumUtil.GetEnumItems(enumTypeName);
			return results;
		}
	}
}
