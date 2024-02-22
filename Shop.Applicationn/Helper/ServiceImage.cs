using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTap.Application.Helper
{
    public class ServiceImage
    {
        public static string createImage(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileSQL = "";
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                var fileExtension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return "";
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    fileSQL = "/Images/" + fileName;
                }
                return fileSQL;
            }
            return "";
        }
        public static bool deleteImage(string filePath)
        {
            try
            {
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + filePath;
                if (!string.IsNullOrEmpty(filePath) && File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static string updateImage(IFormFile file, string currentFilePath)
        {
            if (file != null && file.Length > 0)
            {
                string imagePath = createImage(file);
                if (!string.IsNullOrEmpty(imagePath))
                {
                    if (deleteImage(currentFilePath))
                    {
                        return imagePath;
                    }
                }
            }
            return "";
        }
    }
}
