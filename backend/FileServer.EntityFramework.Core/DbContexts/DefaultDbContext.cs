using EasyRuoyi.Core.Const;
using EasyRuoyi.Core.Entities;
using EasyRuoyi.Core.Utils;
using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Linq;

namespace FileServer.EntityFramework.Core
{
	[AppDbContext("DefaultConnection", DbProvider.SqlServer)]
	public class DefaultDbContext : AppDbContext<DefaultDbContext>
	{
		public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
		{
			// 启用实体数据更改监听
			EnabledEntityChangedListener = true;

			// 忽略空值更新
			InsertOrUpdateIgnoreNullValues = true;
		}

		protected override void SavingChangesEvent(DbContextEventData eventData, InterceptionResult<int> result)
		{
			// 获取当前事件对应上下文
			var dbContext = eventData.Context;
			// 获取所有更改，删除，新增的实体，但排除审计实体（避免死循环）
			var entities = dbContext.ChangeTracker.Entries()
				  .Where(u => u.State == EntityState.Modified || u.State == EntityState.Deleted || u.State == EntityState.Added).ToList();
			if (entities == null || entities.Count < 1) return;

			//// 判断是否是演示环境
			//var demoEnvFlag = App.GetService<ISysConfigService>().GetDemoEnvFlag().GetAwaiter().GetResult();
			//if (demoEnvFlag)
			//{
			//    var sysUser = entities.Find(u => u.Entity.GetType() == typeof(SysUser));
			//    if (sysUser == null || string.IsNullOrEmpty((sysUser.Entity as SysUser).LastLoginTime.ToString())) // 排除登录
			//        throw Oops.Oh(ErrorCode.D1200);
			//}

			// 当前操作者信息
			var userId = App.User?.FindFirst(ClaimConst.CLAINM_USERID)?.Value;
			var name = App.User?.FindFirst(ClaimConst.CLAINM_NAME)?.Value;

			foreach (var entity in entities)
			{
				if (entity.Entity.GetType().IsSubclassOf(typeof(DEntityBase)))
				{
					var obj = entity.Entity as DEntityBase;
					if (entity.State == EntityState.Added)
					{
						obj.Id = obj.Id == Guid.Empty ? GuidUtil.Create() : obj.Id;
						obj.CreatedTime = DateTimeOffset.Now;
						obj.UpdatedTime = DateTimeOffset.Now;
						if (!string.IsNullOrEmpty(userId))
						{
							obj.CreatedUserId = Guid.Parse(userId);
							obj.CreatedUserName = name;
							obj.UpdatedUserId = Guid.Parse(userId);
							obj.UpdatedUserName = name;
						}
					}
					else if (entity.State == EntityState.Modified)
					{
						// 排除创建人
						entity.Property(nameof(DEntityBase.CreatedUserId)).IsModified = false;
						entity.Property(nameof(DEntityBase.CreatedUserName)).IsModified = false;
						// 排除创建日期
						entity.Property(nameof(DEntityBase.CreatedTime)).IsModified = false;

						obj.UpdatedTime = DateTimeOffset.Now;
						if (!string.IsNullOrWhiteSpace(userId))
						{
							obj.UpdatedUserId = Guid.Parse(userId);
							obj.UpdatedUserName = name;
						}

						//针对软删除
						if (obj.IsDeleted && obj.DeletedTime == null)
						{
							obj.DeletedTime = DateTimeOffset.Now;
						}
					}
				}
			}
		}
	}
}
