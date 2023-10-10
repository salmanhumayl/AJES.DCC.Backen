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
        public async Task<bool> CheckPasswordAsync(DccUser user, string Password)
        {
            return true;

        }

        public async Task<DccUser> FindByNameAsync(string UserNAme)
        {
            DccUser user = new DccUser();
            user.Id = 122222;
            user.Name = "Salman";
            user.UserName = "abc";

            return user;
        }
    }
}
