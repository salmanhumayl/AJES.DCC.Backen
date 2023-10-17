using DCC.ModelSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Interface
{
    public interface IuserManager
    {
        Task<DccUser> FindByNameAsync(string UserNAme);
        Task<bool> CheckPasswordAsync(DccUser user, string Password);
        List<string> Test(string UserName);
    }
}
