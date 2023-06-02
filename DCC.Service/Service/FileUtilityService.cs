using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace DCC.Service.Service
{
    public class FileUtilityService : IFileUtilityService
    {
        private IConfiguration _configuration;
        // private IWebHostEnvironment _hostEnvironment;


        public FileUtilityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public (IList<EmpHistory>, string response) ReadBrokerMasterFromExcel(string filePath)
        {
            throw new NotImplementedException();
        }

        public async Task<string> WriteIFormFileOnNetwork(IFormFile file, string fileName)
        {
          string path = _configuration["ShareFolderPath:SupportOfficeOUT"];


            if (file.Length > 0)
            {
                string fileExtension = GetFileExtenison(file.FileName);
                string filePath = Path.Combine(path, fileName + "." + fileExtension);
                try
                {
                    using (Stream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return fileName + "." + fileExtension;
               
            }
            return null;
        }

        public Task<string> WriteIFormFileToDisk(IFormFile file)
        {
            throw new NotImplementedException();
        }


        public string GetFileExtenison(string fileName)
        {
            var fileExtension = fileName.Split('.').LastOrDefault();
            return fileExtension;
        }

        public string GetFileNameWithoutExtension(string path)
        {
            throw new NotImplementedException();
        }

    }
}
