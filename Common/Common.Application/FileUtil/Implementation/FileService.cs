using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Common.Application.FileUtil.Implementation
{
    public class FileService : IFileService
    {
        public void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }

        public void DeleteFile(string directoryPath, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), directoryPath, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public async Task SaveFile(IFormFile file, string directoryPath)
        {
            if (file == null)
                throw new InvalidDataException("File is null");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), directoryPath);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, file.FileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        public async Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath)
        {
            if (file == null)
                throw new InvalidDataException("File is null");

            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}_{DateTime.Now:yyyyMMddHHmmssfff}{extension}";

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), directoryPath);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return fileName;
        }
    }
}
