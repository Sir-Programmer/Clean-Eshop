using Microsoft.AspNetCore.Http;

namespace Common.Application.ImageUtil;

public static class ImageValidator
{
    private static readonly string[] AllowedMimeTypes =
    [
        "image/jpeg",
        "image/png",
        "image/gif",
        "image/bmp",
        "image/webp"
    ];

    private static readonly string[] AllowedExtensions =
    [
        ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp"
    ];

    public static bool IsImage(this IFormFile? file)
    {
        if (file == null)
            return false;

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        var mime = file.ContentType.ToLowerInvariant();

        return AllowedExtensions.Contains(extension) && AllowedMimeTypes.Contains(mime);
    }
}