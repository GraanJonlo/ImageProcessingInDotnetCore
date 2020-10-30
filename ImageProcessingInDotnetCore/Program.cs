using System.Threading.Tasks;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessingInDotnetCore
{
	class Program
	{
		static async Task Main(string[] _)
		{
			var instance = new Program();
			await instance.Run();
		}

		private async Task Run()
		{
			var fontCollection = new FontCollection();
			FontFamily fontFamily = fontCollection.Install("HennyPenny-Regular.ttf");
			Font font = fontFamily.CreateFont(48, FontStyle.Bold);

			using var originalImage = await Image.LoadAsync("pexels-pixabay-355952.jpg");

			// Make a thumbnail

			const int targetWidthForThumbnail = 120;
			int targetHeightForThumbnail = (targetWidthForThumbnail / originalImage.Width) * originalImage.Height;

			using var copyForThumbnail =
				originalImage.Clone(x => x.Resize(targetWidthForThumbnail, targetHeightForThumbnail));

			await copyForThumbnail.SaveAsync("pexels-pixabay-355952-thumb.jpg");

			// A bit more complicated

			const int targetWidthForFresh = 1000;
			int targetHeightForFresh = (targetWidthForFresh / originalImage.Width) * originalImage.Height;

			using var copyForFresh = originalImage.Clone(x => x.Resize(targetWidthForFresh, targetHeightForFresh));

			IPath star = new Star(890, 110, 35, 90, 100);

			copyForFresh.Mutate(x => x.Fill(Color.Red, star));
			copyForFresh.Mutate(x => x.DrawText("Fresh!", font, Color.White, new PointF(825, 60)));

			await copyForFresh.SaveAsync("pexels-pixabay-355952-fresh.jpg");
		}
	}
}
