using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Service
{
    public class FileUtilityService : IFileUtilityService
    {
        private IConfiguration _configuration;
        private IWebHostEnvironment _hostEnvironment;
        public string GetFileNameWithoutExtension(string path)
        {
            throw new NotImplementedException();
        }

        public (IList<EmpHistory>, string response) ReadBrokerMasterFromExcel(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<string> WriteIFormFileOnNetwork(IFormFile file, string FileName)
        {
            throw new NotImplementedException();
        }

        public Task<string> WriteIFormFileToDisk(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
