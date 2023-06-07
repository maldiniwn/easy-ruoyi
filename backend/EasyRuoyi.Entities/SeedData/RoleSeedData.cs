using EasyRuoyi.Entities.Entities;
using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EasyRuoyi.Entities.SeedData;

public class RoleSeedData : IEntitySeedData<Role>
{
	public IEnumerable<Role> HasData(DbContext dbContext, Type dbContextLocator)
	{
		Guid userId = Guid.Parse(App.Configuration["SeedData:UserInfo:Id"]);
		string name = App.Configuration["SeedData:UserInfo:Name"];
		DateTimeOffset time = DateTimeOffset.Parse("2023-1-1");
		return new[]
		{
			new Role{ Id = Guid.Parse(App.Configuration["SeedData:Role:Id"]), Name=App.Configuration["SeedData:Role:Name"], RoleCode = "SuperAdmin", Description = "超级管理员角色，不能修改、删除", IsEnable=true, CreatedUserId=userId, CreatedUserName=name, CreatedTime=time, UpdatedUserId=userId,UpdatedUserName=name,UpdatedTime=time, IsDeleted = false }
		};
	}
}
