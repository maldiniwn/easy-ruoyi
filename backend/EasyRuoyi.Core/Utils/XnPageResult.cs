using Mapster;
using System.Collections.Generic;

namespace EasyRuoyi.Core.Utils
{
	/// <summary>
	/// 分页结果
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PageResult<T>
	{
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int TotalPage { get; set; }
		public int TotalRows { get; set; }
		public ICollection<T> Rows { get; set; }
	}

	/// <summary>
	/// 小诺分页列表结果
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public static class XnPageResult<T> where T : new()
	{
		public static PageResult<V> PageResult<V>(PagedList<T> page)
		{
			return new PageResult<V>
			{
				PageIndex = page.PageIndex,
				PageSize = page.PageSize,
				TotalPage = page.TotalPages,
				TotalRows = page.TotalCount,
				Rows = page.Items.Adapt<List<V>>(),
			};
		}
	}
}