using DCC.ModelSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Interface
{
    public interface IOutgoingService
    {
        IQueryable<DcconGoing> GetOnGoingQuery();
        Task<DcconGoing> GetOutGoingById(int id);
    }
}
