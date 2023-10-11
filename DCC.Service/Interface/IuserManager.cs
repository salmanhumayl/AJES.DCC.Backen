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
        DccUser FindByNameAsync(string UserNAme);
        bool CheckPasswordAsync(DccUser user, string Password);

    }
}
