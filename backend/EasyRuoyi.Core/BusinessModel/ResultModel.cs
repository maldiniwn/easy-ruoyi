using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Core.BusinessModel
{
	/// <summary>
	/// 接口通用返回模型
	/// </summary>
	public class ResultModel
	{
		/// <summary>
		/// Code
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// Message
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Data
		/// </summary>
		public object Data { get; set; }
	}
}
