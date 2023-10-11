using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Interface
{
    public interface IClaimService
    {
        string GetCurrentUserID();
        string GetCurrentUserName();
        string GetCurrentDisplayName();
    }
}
