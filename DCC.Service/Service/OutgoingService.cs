using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Service
{
    public class OutgoingService : IOutgoingService
    {
        private readonly IRepository _repository;

        public OutgoingService(IRepository repository)
        {
            _repository = repository;
           
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
    }
}
