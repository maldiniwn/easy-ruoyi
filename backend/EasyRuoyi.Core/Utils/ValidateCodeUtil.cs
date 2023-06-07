using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Linq;

namespace EasyRuoyi.Core.Utils
{
	/// <summary>
	/// 验证码工具
	/// </summary>
	public static class ValidateCodeUtil
	{
		private static readonly Color[] colors = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
		private static readonly char[] chars = { '0','1','2','3','4','5','6','7','8','9'
					,'a','b','c','d','e','f','g','h','i','j','k','m','n','p','q','r','s','t','u','v','w','x','y','z'
					,'A','B','C','D','E','F','G','H','J','K','L','M','N','P','Q','R','S','T','U','V','W','X','Y','Z' };

		/// <summary>
		/// 生成验证码
		/// </summary>
		/// <param name="length">指定验证码的长度</param>
		/// <returns></returns>
		private static string GenCode(int length = 4)
		{
			var code = string.Empty;
			var r = new Random();

			for (int i = 0; i < length; i++)
			{
				code += chars[r.Next(chars.Length)].ToString();
			}

			return code;
		}

		/// <summary>
		/// 创建验证码的图片
		/// </summary>
		/// <param name="length"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <returns></returns>
		public static (string code, byte[] bytes) CreateValidateGraphic(int length = 4, int width = 90, int height = 30)
		{
			var code = GenCode(length);
			var r = new Random();
			var image = new Image<Rgba32>(width, height);
			int fontSize = 25;
			// 字体
			var font = SystemFonts.CreateFont(SystemFonts.Families.First().Name, fontSize, FontStyle.Bold);
			image.Mutate(ctx =>
			{
				// 白底背景
				ctx.Fill(Color.White);

				// 画验证码
				for (int i = 0; i < code.Length; i++)
				{
					ctx.DrawText(code[i].ToString()
						, font
						, colors[r.Next(colors.Length)]
						, new PointF(20 * i + 10, r.Next(2, 4)));
				}

				// 画干扰线
				for (int i = 0; i < 6; i++)
				{
					var pen = new Pen(colors[r.Next(colors.Length)], 1);
					var p1 = new PointF(r.Next(width), r.Next(height));
					var p2 = new PointF(r.Next(width), r.Next(height));

					ctx.DrawLines(pen, p1, p2);
				}

				// 画噪点
				for (int i = 0; i < 60; i++)
				{
					var pen = new Pen(colors[r.Next(colors.Length)], 1);
					var p1 = new PointF(r.Next(width), r.Next(height));
					var p2 = new PointF(p1.X + 1f, p1.Y + 1f);

					ctx.DrawLines(pen, p1, p2);
				}
			});
			var ms = new MemoryStream();

			//  格式 自定义
			image.SaveAsPng(ms);
			return (code, ms.ToArray());
		}
	}
}
