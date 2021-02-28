using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
   public  class FileHelper
    {
        public static string FilePath(IFormFile file)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString("N")
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;

            string path = Environment.CurrentDirectory + @"\Images\carImages";

            string result = $@"{path}\{creatingUniqueFilename}";

            return result;
        }

        public static string AddAsync(IFormFile file)
        {
            var result = FilePath(file);
            try
            {
                // full path to file in temp location
                var sourcepath = Path.GetTempFileName();
                if (file.Length > 0)
                {

                    using (var stream = new FileStream(sourcepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                File.Move(sourcepath, result);

            }
            catch (Exception exception)
            {

                return exception.Message;
            }
            return result;
        }

        public static string UpdateAsync(string sourcepath, IFormFile file)
        {
            var result = FilePath(file);
            try
            {
                if (sourcepath.Length > 0)
                {
                    using (var stream = new FileStream(result, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }


                File.Delete(sourcepath);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }
            return result;
        }


        public static IResult DeleteAsync(string path)
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


    }
}

