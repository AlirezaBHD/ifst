using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace ifst.API.ifst.Infrastructure.FileManagement
{
    public class FileService
    {
        private readonly string _basePath;

        public FileService()
        {
            _basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);
        }

        public async Task<string> SaveFileAsync(IFormFile file, string category)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file");

            // مسیر کامل برای فولدر دسته‌بندی
            var categoryPath = Path.Combine(_basePath, category);

            // اطمینان از وجود پوشه دسته‌بندی
            if (!Directory.Exists(categoryPath))
                Directory.CreateDirectory(categoryPath);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(categoryPath, fileName);

            // ذخیره فایل
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // برگرداندن مسیر نسبی فایل
            return Path.Combine(category, fileName);
        }

        public void DeleteFile(string relativePath)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}