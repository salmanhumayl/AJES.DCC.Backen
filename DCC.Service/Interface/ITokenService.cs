
using DCC.Model.Models;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Interface
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(LoginModel model);
    }
}
