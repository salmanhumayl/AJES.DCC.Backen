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
       
       
        public OutgoingService(IRepository repository, IMapper iMapper)
        {
            _repository = repository;
            _iMapper = iMapper;
           

        }

        public async Task<string> AddOutGoing(DcconGoingModel DcconGoingModel)
        {
            DcconGoing Ongoing = _iMapper.Map<DcconGoing>(DcconGoingModel);
            Ongoing.CreatedBy = "smazhar";
            Ongoing.CreatedDate = DateTime.Now;
            _repository.InsertModel(Ongoing);
            await _repository.SaveAsync();
            return "T";
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

        public Task<string> ProcessDocument(IFormFile files, string FileName)
        {
           
            return null;
        }

        public Task UpdateOutGoing(DcconGoingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
