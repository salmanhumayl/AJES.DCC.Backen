using DCC.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCC.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class MenuController : ControllerBase
    {

        private IMenubar _MenubarService;
        public MenuController(IMenubar MenubarService)
        {
            _MenubarService = MenubarService;
        }

        [HttpGet("GetMenuBar")]
        public IActionResult GetRights()
        {
            var result = _MenubarService.GetMenuBar();
            return Ok(result);
        }

        [HttpGet("GetRegister")]
        public IActionResult GetRegister(int FolderID)
        {
            var data = _MenubarService.GetRegister(FolderID);
            return Ok(data);
        }
    }
}