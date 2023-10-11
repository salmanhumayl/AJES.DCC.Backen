using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private IuserManager userManager;

        public ResourceOwnerPasswordValidator(IuserManager userManager)
        {
            this.userManager = userManager;
        }
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            DccUser user = userManager.FindByNameAsync(context.UserName);
           
            if (user != null)
            {
                if (userManager.CheckPasswordAsync(user, context.Password))
                {
                    context.Result = new GrantValidationResult(
                        subject: user.UserName,
                        authenticationMethod: "custom");
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect pasword..");
                }
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User does not exist.");
            }

            return Task.CompletedTask;
        }
    }
 }



