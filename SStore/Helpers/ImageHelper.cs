using System;
using System.IO;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Components.Forms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using SStore.Model.Data.Entities;

namespace SStore.Helpers
{
    public interface IImageHelper
    {
        string PathToBase64String(string path, int? width);
       Task< AppStorge?> uploadImage(IBrowserFile file);
        (bool result, string? error) ValidateImage(IBrowserFile file);
    }
    public class ImageHelper: IImageHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageHelper(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }
        public static string ConvertMemoryStreamToBase64String(MemoryStream memoryStream)
        {
            if (memoryStream == null || memoryStream.Length == 0)
            {
                return string.Empty;
            }

            byte[] imageBytes = memoryStream.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
        public  string? PathToBase64String(string fileName,int? width)
        {
            var contentRootPath = _webHostEnvironment.WebRootPath; 
            var imagePath= Path.Combine(contentRootPath, fileName);
            try
            {
                var img = Image.Load(imagePath);
                if (img == null)
                    return null;
                var newImage = ResizeImage(img, width ?? 120);
                var encoder = new JpegEncoder();

                return ConvertImageToBase64String(newImage!, encoder);
            }
            catch   
            {

                return null;
            }
            
        }


        public async Task <AppStorge?> uploadImage(IBrowserFile file)
        {
            var folder = _webHostEnvironment.WebRootPath;
            var imagesPath = Path.Combine("files", "images");
            var fullImagesPath= Path.Combine(folder, imagesPath);
            if (!Directory.Exists(fullImagesPath))
            {
                Directory.CreateDirectory(fullImagesPath);
            }
            var fileName = Path.GetRandomFileName()+Path.GetExtension(file.Name);
            var fullFileName = Path.Combine(fullImagesPath,fileName);

            using (var fileStream = new FileStream(fullFileName, FileMode.Create, FileAccess.Write))
            {
                await file.OpenReadStream().CopyToAsync(fileStream);
            }

            var appStorege = new AppStorge
            {

                FileName = Path.Combine(imagesPath, fileName),
                FileSize = file.Size,
                FileType = Path.GetExtension(file.Name),

            };
            return appStorege;
        }
        private Image? ResizeImage(Image inputImage, int newWidth, int? newHeight = null)
        {
            if (inputImage == null)
            {
                return null;
            }
            var changePersenting = newWidth / inputImage.Width;
            if (newHeight == null)
            {
                newHeight = inputImage.Height * changePersenting;
            }
            inputImage.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(newWidth, newHeight ?? newWidth),
                Mode = ResizeMode.Max
            }));

            return inputImage;
        }

       
          public (bool result, string? error) ValidateImage(IBrowserFile file)
          {
            if (file == null) return (false, "عذرا لم يتم العثور على الصورة");

            var allowExt = new List<string> { ".jpg", ".jpeg", ".png" };
            long maxSize = 1 * 1024 * 1024;
            var fileExt = Path.GetExtension(file.Name).ToLowerInvariant();
            if (file.Size > maxSize)
            {
                return (false, "عذرا حجم الملف أكبر من المحدد");
            }
            if (!allowExt.Contains(fileExt))
            {
                return (false, "عذرا امتداد الصورة غير مدعومة");
            }
            return (true, null);
        }
        public (bool result,string? error)ValidateImage(IFormFile file)
        {
            if (file == null) return (false, "عذرا لم يتم العثور على الصورة");

            var allowExt = new List<string> { ".jpg", ".jpeg", ".png" };
            long maxSize = 1 * 1024 * 1024;
            var fileExt=Path.GetExtension(file.Name).ToLowerInvariant();
            if(file.Length>maxSize)
            {
                return (false, "عذرا حجم الملف أكبر من المحدد");
            }
            if (!allowExt.Contains(fileExt))
            {
                return (false, "عذرا امتداد الصورة غير مدعومة");
            }
            return (true, null);
        }

        private string ConvertImageToBase64String(Image image, IImageEncoder encoder)
        {
            if (image == null)
            {
                return string.Empty;
            }

            using var memoryStream = new MemoryStream();
            image.Save(memoryStream, encoder);
            byte[] imageBytes = memoryStream.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

    }


}
