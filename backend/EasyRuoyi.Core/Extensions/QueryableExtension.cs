using EasyRuoyi.Core.Entities;
using System.Linq;

namespace EasyRuoyi.Core.Extensions
{
	public static class QueryableExtension
	{
		/// <summary>
		/// 过滤软删除
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="includDeleted"></param>
		/// <returns></returns>
		public static IQueryable<T> Query<T>(this IQueryable<T> query, bool includDeleted = false) where T : DEntityBase
		{
			if (includDeleted) return query;
			else return query.Where(t => t.IsDeleted == false);
		}
	}
}
