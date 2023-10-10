using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Service
{
    public class userManagerService : IuserManager
    {
        public Task<bool> CheckPasswordAsync(DccUser user, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<DccUser> FindByNameAsync(string UserNAme)
        {
            throw new NotImplementedException();
        }
    }
}
