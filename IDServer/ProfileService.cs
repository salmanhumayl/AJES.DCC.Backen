using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VCT.Core.Entities;
using VCT.Service.Interface;

namespace IDServer
{
    public class ProfileService : IProfileService
    {
        private UserManager<IdentityUser> _userManager;
        private IAuthenticate _authenticaterepository;
        public ProfileService(UserManager<IdentityUser> userManager, IAuthenticate authenticaterepository)
        {
            _userManager = userManager;
            _authenticaterepository = authenticaterepository;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
          
            var user = await _userManager.FindByNameAsync(context.Subject.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault().Value);
           

            var claims = new List<Claim>
            {
                 new Claim("Id", user.Id),
                 new Claim("UserName", user.UserName),
                 new Claim("Name", user.Name),
                
                 new Claim(ClaimTypes.Name, user.UserName)
            };
            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.FindByNameAsync(context.Subject.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault().Value);
            context.IsActive = (user == null) ? false : true;
        }
    }
}
