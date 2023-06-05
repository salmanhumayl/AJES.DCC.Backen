using AutoMapper;
using DCC.Model.Models;
using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DCC.Service.Service
{
    public class OutgoingService : IOutgoingService
    {
        private readonly IRepository _repository;
        private IMapper _iMapper;
        private readonly IFileUtilityService _fileUtilityService;
      
        public OutgoingService(IRepository repository, IMapper iMapper, IFileUtilityService fileUtilityService)
        {
            _repository = repository;
            _iMapper = iMapper;
            _fileUtilityService = fileUtilityService;


        }

        public async Task<int> AddOutGoing(DcconGoingModel DcconGoingModel)
        {
            DcconGoing Ongoing = _iMapper.Map<DcconGoing>(DcconGoingModel);
            Ongoing.CreatedBy = "smazhar";
            Ongoing.CreatedDate = DateTime.Now;
            _repository.InsertModel(Ongoing);
            await _repository.SaveAsync();
            return Ongoing.Id;
        }

        public IQueryable<DcconGoing> GetOnGoingQuery()
        {
            var data = _repository.GetQueryable<DcconGoing>();
            return data;
        }

        public async Task<DcconGoing> GetOutGoingById(int id)
        {
            return await _repository.GetModelByIdAsync<DcconGoing>(id);
        }

        public async Task<string> ProcessDocument(IFormFile files, string FileName)
        {

            var filePath = await _fileUtilityService.WriteIFormFileOnNetwork(files, FileName);
            return filePath;
        }

        public async Task UpdateOutGoing(DcconGoingModel DcconGoingModel)
        {
            DcconGoing Ongoing = _iMapper.Map<DcconGoing>(DcconGoingModel);
            Ongoing.UpdatedBy = "smazhar";
            Ongoing.UpdatedDate = DateTime.Now;
            _repository.UpdateModel(Ongoing);
            await _repository.SaveAsync();
        }

        public void UpdateFileName(string FileName, int id)
        {
            _repository.ExecuteRowSql("Update DCCOnGoing Set Path='" + FileName + "' Where id =" + id);
        }
    }
}
