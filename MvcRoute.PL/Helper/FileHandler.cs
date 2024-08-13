using Microsoft.AspNetCore.Http;
using System;
using System.IO;


namespace MvcRoute.BLL.Helper
{
    public class FileHandler
    {
        public static string UploadFile(IFormFile file, string folderName) {

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets", folderName);
            string fileName = Guid.NewGuid()+file.FileName;
            string filePath = Path.Combine(folderPath, fileName);
            using var fs = new FileStream(filePath,FileMode.Create);
            file.CopyTo(fs);
            return fileName;
        }   
        public static int DeleteFile(string fileName, string folderName) {

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets", folderName , fileName);

            try {
                File.Delete(folderPath);
                return 1;
            }catch{
            return -1;
            }
        }

    }
}
