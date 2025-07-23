using Microsoft.AspNetCore.Http;

namespace Common.Application.FileUtil
{
    public static class FileValidation
    {
        public static bool IsValidFile(this IFormFile? file)
        {
            if (file == null) return false;
            var path = Path.GetExtension(file.FileName);
            path = path.ToLower();
            return path is ".mp4" or ".mp3" or ".zip" or ".rar" or ".wav" or ".docx" or ".mmf" or ".m4a" or ".ogg"
                or ".doc" or ".pdf" or ".txt" or ".xls" or ".xla" or ".xlsx" or ".ppt" or ".pptx" or ".gif" or ".jpg"
                or ".png" or ".tif" or ".wmv" or ".bmp" or ".wmf" or ".gif" or ".log";
        }

        public static bool IsValidImageFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return false;
            var path = Path.GetExtension(fileName);
            path = path.ToLower();
            return path is ".jpg" or ".png" or ".bmp" or ".svg" or ".jpeg";
        }
    }
}