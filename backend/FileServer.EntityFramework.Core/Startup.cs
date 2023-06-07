using Furion;
using Furion.DatabaseAccessor;
using Microsoft.Extensions.DependencyInjection;

namespace FileServer.EntityFramework.Core
{
	public class Startup : AppStartup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDatabaseAccessor(options =>
			{
				// EF批量组件 : EF core 7.0 新增了批量删除、修改功能
				//https://learn.microsoft.com/zh-cn/ef/core/what-is-new/ef-core-7.0/whatsnew?WT.mc_id=DT-MVP-5004444#executeupdate-and-executedelete-bulk-updates
				options.AddDbPool<DefaultDbContext>(DbProvider.SqlServer);
			}, "FileServer.Database.Migrations");
		}
	}
}
