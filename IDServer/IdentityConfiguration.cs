using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


// scope is an end point which we want to secure 
namespace IDServer
{
    public class IdentityConfiguration
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
    new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        
    };

        public static IEnumerable<ApiScope> ApiScopes =>
    new ApiScope[]
    {
        new ApiScope("vct-api", "VCT Api"),
       
    };


        public static IEnumerable<ApiResource> ApiResources =>
    new ApiResource[]
    {
         new ApiResource("vct-api", "VCT Api")
                {
                    Scopes = { "vct-api" }
                }
    };

        public static IEnumerable<Client> Clients =>
    new Client[]
    {
        new Client
        {

            ClientName = "DCC",
            ClientId = "DCC.Client",
             RequireClientSecret = false,
            AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedScopes = { "DCC-api" },
           // AllowOfflineAccess = false,
           // RefreshTokenExpiration = TokenExpiration.Sliding,
           // SlidingRefreshTokenLifetime = 3600,
           // AbsoluteRefreshTokenLifetime = 28800,
            AccessTokenLifetime = 86400, // One Day 

        },
    };

    }
}


