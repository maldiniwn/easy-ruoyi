using EasyRuoyi.Core.Enums;
using EasyRuoyi.Entities.Entities;
using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EasyRuoyi.Entities.SeedData
{
	public class EmployeeSeedData : IEntitySeedData<Employee>
	{
		public IEnumerable<Employee> HasData(DbContext dbContext, Type dbContextLocator)
		{
			Guid userId = Guid.Parse(App.Configuration["SeedData:UserInfo:Id"]);
			string name = App.Configuration["SeedData:UserInfo:Name"];
			DateTimeOffset time = DateTimeOffset.Parse("2023-1-1");

			return new[]
			{
				new Employee{ Id = userId, Name = name, EnumGender = EnumGender.Male, CreatedUserId=userId, CreatedUserName=name, CreatedTime=time, UpdatedUserId=userId,UpdatedUserName=name,UpdatedTime=time, IsDeleted = false}
			};
		}
	}
}
