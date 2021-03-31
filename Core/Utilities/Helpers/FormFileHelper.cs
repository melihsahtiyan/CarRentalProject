using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers
{
    public class FormFileHelper
    {
        public static string Add(IFormFile formFile)
        {
            var result = FileStorageTool(formFile);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (formFile.Length > 0)
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                        formFile.CopyTo(stream);
                File.Move(sourcePath, result.newGuidPath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result.oldGuidPath;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string Update(IFormFile file, string pathToUpdate)
        {
            var result = FileStorageTool(file);
            try
            {
                if (pathToUpdate.Length>0)
                {
                    using (var stream = new FileStream(result.newGuidPath,FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(pathToUpdate);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

            return result.oldGuidPath;
        }
        public static (string newGuidPath, string oldGuidPath) FileStorageTool(IFormFile formFile)
        {
            FileInfo file = new FileInfo(formFile.FileName);
            string fileExtension = file.Extension;

            var newGuidPath = Guid.NewGuid().ToString("D") + fileExtension;

            string path = Environment.CurrentDirectory + @"\wwwroot\images";

            string result = $@"{path}\{newGuidPath}";

            return (result, $"\\images\\{newGuidPath}");
        }
    }
}
