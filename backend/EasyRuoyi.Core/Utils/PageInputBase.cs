using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRuoyi.Core.Utils
{
	public class PageInputBase
	{
		/// <summary>
		/// 当前页码
		/// </summary>
		public virtual int PageIndex { get; set; } = 1;

		/// <summary>
		/// 页码容量
		/// </summary>
		public virtual int PageSize { get; set; } = 10;

		/// <summary>
		/// 排序字段
		/// </summary>
		public virtual string SortField { get; set; }

		/// <summary>
		/// 排序方法,默认升序
		/// </summary>
		public virtual string SortType { get; set; } = "ASC";
	}
}
