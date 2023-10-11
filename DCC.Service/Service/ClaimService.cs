using DCC.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Service
{
    public class ClaimService : IClaimService
    {
        private IHttpContextAccessor _httpContextAccessor;
        

        public ClaimService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            
        }
        public string GetCurrentDisplayName()
        {
            return _httpContextAccessor.HttpContext != null ?
                  _httpContextAccessor.HttpContext.User.Claims.Where(a => a.Type.Equals("Name")).Select(a => a.Value).FirstOrDefault() : "";
        }
        public string GetCurrentUserID()
        {
            return _httpContextAccessor.HttpContext != null ?
                _httpContextAccessor.HttpContext.User.Claims.Where(a => a.Type.Equals("Id")).Select(a => a.Value).FirstOrDefault() : "";
        }
        public string GetCurrentUserName()
        {
            return _httpContextAccessor.HttpContext != null ?
               _httpContextAccessor.HttpContext.User.Claims.Where(a => a.Type.Equals("UserName")).Select(a => a.Value).FirstOrDefault() : "";
        }
    }
}
