using DCC.API.Model;
using DCC.Model.Models;
using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private IuserManager _userManager;

        public AuthenticateController(ITokenService tokenservice, IuserManager userManager)
        {
            _ITokenService = tokenservice;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginIn(LoginModel model)
        {


            var resp = await _ITokenService.GetToken(model);
           
          //  return Ok(new Response { Status= resp.ErrorDescription,AccessToken=resp.AccessToken,gg= JsonConvert.SerializeObject( resp), Message = "Sorry! We could not verify your UserNane or password. Please try again." });

            if (resp.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var users=await _userManager.FindByNameAsync(model.UserName);
                return Ok(GetTokenResponse(resp.AccessToken, DateTimeOffset.UtcNow.AddSeconds(resp.ExpiresIn),users.Name));
            }
            //    return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Sorry! We could not verify your email or password. Please try again." });
            return Ok(new Response { Status = "Error", Message = "Sorry! We could not verify your UserNane or password. Please try again.", gg = JsonConvert.SerializeObject(resp) });
        }

        private DCCTokenResponse GetTokenResponse(string token, DateTimeOffset validUpto,string Name)
        {
            return new DCCTokenResponse()
            {
                Status = "ok",
                token = token,
                expiration = validUpto.LocalDateTime,
                Name=Name
            };
        }

    }
 }

