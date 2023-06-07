using EasyRuoyi.Core.Const;
using EasyRuoyi.Core.Entities;
using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRuoyi.Core.Extensions
{
	public static class SoftDeleteExtension
	{
		/// <summary>
		/// 软删除
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="repository"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static async Task SoftDeleteAsync<TEntity>(this IRepository<TEntity> repository, TEntity entity) where TEntity : DEntityBase, new()
		{
			if (null != entity)
			{
				entity.IsDeleted = true;
				entity.DeletedTime = DateTimeOffset.Now;
				await repository.UpdateAsync(entity);
			}
		}

		/// <summary>
		/// 批量软删除
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="repository"></param>
		/// <param name="ids"></param>
		/// <returns></returns>
		public static async Task SoftDeleteAsync<TEntity>(this IRepository<TEntity> repository, params Guid[] ids) where TEntity : DEntityBase, new()
		{
			if (null != ids && ids.Length > 0)
			{
				// 当前操作者信息
				var userId = App.User?.FindFirst(ClaimConst.CLAINM_USERID)?.Value;
				var name = App.User?.FindFirst(ClaimConst.CLAINM_NAME)?.Value;

				if (string.IsNullOrWhiteSpace(userId))
				{
					await repository.Entities.Where(a => ids.Contains(a.Id))
									.ExecuteUpdateAsync(s => s
										.SetProperty(b => b.IsDeleted, true)
										.SetProperty(b => b.DeletedTime, DateTimeOffset.Now)
										.SetProperty(b => b.UpdatedTime, DateTimeOffset.Now));
				}
				else
				{
					await repository.Entities.Where(a => ids.Contains(a.Id))
									.ExecuteUpdateAsync(s => s
										.SetProperty(b => b.IsDeleted, true)
										.SetProperty(b => b.DeletedTime, DateTimeOffset.Now)
										.SetProperty(b => b.UpdatedUserId, Guid.Parse(userId))
										.SetProperty(b => b.UpdatedUserName, name)
										.SetProperty(b => b.UpdatedTime, DateTimeOffset.Now));
				}
			}
		}
	}
}
