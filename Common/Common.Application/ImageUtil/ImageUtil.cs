using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace Common.Application.ImageUtil;

public static class ImageConvertor
{
    public static void CreateBitmap(string inputImagePath, string outputPath, int newWidth, int newHeight)
    {
        var inputFile = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{inputImagePath.Replace("/", "\\")}");
        var imageName = Path.GetFileName(inputImagePath);
        var outputFolder = Path.Combine(Directory.GetCurrentDirectory(), outputPath.Replace("/", "\\"));

        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);

        var outputFile = Path.Combine(outputFolder, imageName);
        ResizeImage(inputFile, outputFile, newWidth, newHeight);
    }

    private static void ResizeImage(string inputPath, string outputPath, int width, int height)
    {
        using var image = Image.Load(inputPath);
        image.Mutate(x => x.Resize(width, height));

        image.Save(outputPath, new JpegEncoder
        {
            Quality = 50 
        });
    }

    public static void CompressImage(string inputPath, string outputPath, int quality)
    {
        using var image = Image.Load(inputPath);

        image.Save(outputPath, new JpegEncoder
        {
            Quality = quality
        });
    }
}