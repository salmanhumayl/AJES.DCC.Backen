using AutoMapper;
using DCC.Model.Models;
using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Service
{
    public class InComingService : IInComingService
    {
        private readonly IRepository _repository;
        private IMapper _iMapper;
        private readonly IFileUtilityService _fileUtilityService;

        public InComingService(IRepository repository, IMapper iMapper, IFileUtilityService fileUtilityService)
        {
            _repository = repository;
            _iMapper = iMapper;
            _fileUtilityService = fileUtilityService;


        }

        public Task<int> AddInComing(DccinComingModel model)
        {
            throw new NotImplementedException();
        }

        public Task<DccinComing> GetInComingById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DccinComing> GetInComingQuery()
        {
            var data = _repository.GetQueryable<DccinComing>();
            return data;
        }

        public Task<string> ProcessDocument(IFormFile files, string FileName)
        {
            throw new NotImplementedException();
        }

        public void UpdateFileName(string FileName, int ID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateInComing(DccinComingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
