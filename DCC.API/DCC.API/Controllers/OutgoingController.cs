using DCC.API.Extensions;
using DCC.Service.Interface;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCC.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutgoingController : ControllerBase
    {

        private IOutgoingService _OutgoingService;
        public OutgoingController(IOutgoingService OutgoingService)
        {
            _OutgoingService = OutgoingService;
        }

        [HttpGet("GetInComing")]
        public async Task<LoadResult> GetInComing(DataSourceLoadOptionsExtension loadOptions)
        {
            loadOptions.PrimaryKey = new string[] { "ID" };

            var queryable = _OutgoingService.GetOnGoingQuery();

            var loadResult = await DataSourceLoader.LoadAsync(queryable, loadOptions);

            return loadResult;
        }

        [HttpGet("GetOutGoingById")]

        public async Task<IActionResult> GetOutGoingById(int ID)
        {
            var result = await _OutgoingService.GetOutGoingById(ID);
             return Ok(result);


        }
    }
}
