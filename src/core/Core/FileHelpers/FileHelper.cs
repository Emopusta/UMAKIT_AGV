﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FileHelpers
{
    public static class FileHelper
    {
        public static void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);

            }
            return Upload(file, root);
        }



        public static string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))

                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GUIDHelper.CreateGuid();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }


    }
}