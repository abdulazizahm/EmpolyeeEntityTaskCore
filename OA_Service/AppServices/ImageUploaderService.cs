using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.AppServices
{
    public enum Directories
    {
       Empolyees  
    }
   public class ImageUploaderService
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public IFormFile ImageFile { get; set; }
        public ImageUploaderService(IFormFile file, Directories dir)
        {
            if (file != null)
            {
              
                FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                this.ImageFile = file;

                FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/"+dir.ToString(), FileName);
  
            }
            else
            {
                FileName = "default.jpg";
            }
        }
        public string GetImageName()
        {
            return FileName;
        }
        public async Task SaveImageAsync()
        {
            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await ImageFile.CopyToAsync(stream);
            }
        }

        public static void DeleteImage(string fileName, Directories dir)
        {
         
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\" + dir.ToString(), fileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
