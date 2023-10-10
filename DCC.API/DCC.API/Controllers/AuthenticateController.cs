using DCC.Model.Models;
using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private ITokenService _ITokenService;

        public AuthenticateController(ITokenService tokenservice)
        {
            _ITokenService = tokenservice;
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginIn(LoginModel model)
        {


            var resp = await _ITokenService.GetToken(model);

            return Ok(GetTokenResponse(resp.AccessToken, DateTimeOffset.UtcNow.AddSeconds(resp.ExpiresIn)));
        }

        private DCCTokenResponse GetTokenResponse(string token, DateTimeOffset validUpto)
        {
            return new DCCTokenResponse()
            {
                token = token,
                expiration = validUpto.LocalDateTime
            };
        }

    }
 }

