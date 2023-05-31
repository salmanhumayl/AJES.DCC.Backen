using DCC.ModelSQL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Interface
{
    public interface IFileUtilityService
    {
        string GetFileNameWithoutExtension(string path);
        Task<string> WriteIFormFileToDisk(IFormFile file);

        Task<string> WriteIFormFileOnNetwork(IFormFile file, string FileName);

        (IList<EmpHistory>, string response) ReadBrokerMasterFromExcel(string filePath);
    }
}
