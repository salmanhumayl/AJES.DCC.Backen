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
    [Route("api/[controller]")]
    [ApiController]
    public class InComingController : ControllerBase
    {
        private IInComingService _InComingService;
        private readonly IDocInfo _DocinfoService;
        private readonly IFileUtilityService _FileServiceUtility;

        public InComingController(IInComingService InComingService, IDocInfo DocinfoService, IFileUtilityService FileServiceUtility)
        {
            _InComingService = InComingService;
            _DocinfoService = DocinfoService;
            _FileServiceUtility = FileServiceUtility;
        }

        [HttpGet("GetInComing")]
        public async Task<LoadResult> GetInComing(DataSourceLoadOptionsExtension loadOptions)
        {
            loadOptions.PrimaryKey = new string[] { "ID" };

            var queryable = _InComingService.GetInComingQuery();

            var loadResult = await DataSourceLoader.LoadAsync(queryable, loadOptions);

            return loadResult;
        }
    }
}
