using DCC.Service.Interface;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace IDServer
{
    public class ProfileService : IProfileService
    {
        private IuserManager _userManager;
        public ProfileService(IuserManager userManager)
        {
            this._userManager = userManager;
         
        }
        public  async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {

            var contextusername = context.Subject.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault().Value;

            var user =await  _userManager.FindByNameAsync(contextusername);
           

            var claims = new List<Claim>
            {
                 new Claim("Id", user.Id.ToString()),
                 new Claim("UserName", user.UserName),
                 new Claim("Name", user.Name),
                
                 new Claim(ClaimTypes.Name, user.UserName)
            };
            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var contextusername = context.Subject.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault().Value;
            var user = _userManager.FindByNameAsync(contextusername);
            context.IsActive = (user == null) ? false : true;
        }
    }
}
