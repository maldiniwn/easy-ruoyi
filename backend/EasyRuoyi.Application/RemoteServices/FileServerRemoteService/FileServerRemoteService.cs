using EasyRuoyi.Core.BusinessModel;
using EasyRuoyi.Core.Utils;
using Furion.Logging.Extensions;
using Furion.RemoteRequest.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EasyRuoyi.Application.RemoteServices.FileServerRemoteService
{
	/// <summary>
	/// 调用文件服务
	/// </summary>
	public class FileServerRemoteService : IFileServerRemoteService, ITransient
	{
		/// <summary>
		/// FileServerRemoteService
		/// </summary>
		public FileServerRemoteService()
		{

		}

		/// <summary>
		/// 查询文件列表
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		public async Task<string> GetSysFiles(Guid[] ids)
		{
			try
			{
				string url = $"{App.Configuration["ServiceConfig:FileServer:Host"].TrimEnd('/')}/sysfile/getSysFiles";
				var resp = await url.SetQueries(new { ids }).GetAsync();
				string jsonStr = await resp.Content.ReadAsStringAsync();
				XnRestfulResult<List<UploadItemModel>> result = JsonConvert.DeserializeObject<XnRestfulResult<List<UploadItemModel>>>(jsonStr);
				List<UploadItemModel> uploadItems = result.Data;
				string jsonResult = JsonConvert.SerializeObject(uploadItems, new JsonSerializerSettings
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				});
				return jsonResult;
			}
			catch (Exception ex)
			{
				$"{ex.Message}{ex.StackTrace}".LogError<FileServerRemoteService>();
				return "";
			}
		}
	}
}
