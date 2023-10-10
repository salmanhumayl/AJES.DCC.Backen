using DCC.Model.Models;
using DCC.Service.Interface;

using IdentityModel.Client;

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<TokenResponse> GetToken(LoginModel model)
        {
            HttpClient httpClient = new System.Net.Http.HttpClient();
              string Address = _configuration["Identity:Authority"] + "/connect/token";


            var requestpaylaod = new PasswordTokenRequest
            {
                Address = Address,
                GrantType = "password",
                ClientId = "dcc.client",
                ClientSecret = "secret",
                Scope = "dcc-api",
                UserName = model.UserName,
                Password = model.Password
            };

            return await httpClient.RequestPasswordTokenAsync(requestpaylaod);
        
        }
    }
}
