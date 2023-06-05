using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Service
{
    public class DocInfoService : IDocInfo
    {
        private readonly IRepository _repository;

        public DocInfoService(IRepository repository)
        {
            _repository = repository;
          

        }
       
        public async Task<DocInfo> GetDocInfo(string ProjectCode, string DocCode)
        {
            return await _repository.GetQueryable<DocInfo>().Where(a => a.Project == ProjectCode && a.DocCode == DocCode).FirstOrDefaultAsync();
        }

        public async Task UpdateDocInfo(DocInfo model)
        {
            try
            {
                _repository.UpdateModel(model);
                await _repository.SaveAsync();
            }

            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
