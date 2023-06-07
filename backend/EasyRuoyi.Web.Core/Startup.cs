using EasyRuoyi.Core.Options;
using EasyRuoyi.Core.Utils;
using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace EasyRuoyi.Web.Core
{
	public class Startup : AppStartup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddConfigurableOptions<RefreshTokenSettingOptions>();
			services.AddJwt<JwtHandler>(enableGlobalAuthorize: true);

			services.AddRemoteRequest();
			services.AddCorsAccessor();

			services.AddControllers()
					.AddNewtonsoftJson(options =>
					{
						// 首字母小写(驼峰样式)
						options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
						// 时间格式化
						options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
						// 忽略循环引用
						options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
						// 忽略空值
						// options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;)
					})
					.AddInjectWithUnifyResult<XnRestfulResultProvider>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			// 添加状态码拦截中间件
			app.UseUnifyResultStatusCodes();

			app.UseStaticFiles();

			//app.UseHttpsRedirection();

			// Serilog请求日志中间件---必须在 UseStaticFiles 和 UseRouting 之间
			app.UseSerilogRequestLogging();

			app.UseRouting();

			app.UseCorsAccessor();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseInject(string.Empty);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}