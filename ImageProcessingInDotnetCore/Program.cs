using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessingInDotnetCore
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var instance = new Program();
			await instance.Run();
		}

		private async Task Run()
		{
			using var image = await Image.LoadAsync("pexels-pixabay-355952.jpg");

			const int targetWidth = 50;

			int targetHeight = (targetWidth / image.Width) * image.Height;

			image.Mutate(x => x.Resize(targetWidth, targetHeight));

			await image.SaveAsync("pexels-pixabay-355952-thumb.jpg");
		}
	}
}
