using DCC.Model.Models;
using DCC.ModelSQL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Interface
{
    public interface IInComingService
    {
        IQueryable<DccinComing> GetInComingQuery();
        Task<DccinComing> GetInComingById(int id);

        Task<int> AddInComing(DccinComingModel model);
        Task UpdateInComing(DccinComingModel model);

        Task<string> ProcessDocument(IFormFile files, string FileName);

        void UpdateFileName(string FileName, int ID);
    }
}
