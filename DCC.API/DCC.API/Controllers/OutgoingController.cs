using DCC.API.Extensions;
using DCC.Model.Models;
using DCC.ModelSQL.Models;
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
   
    public class OutGoingController : ControllerBase
    {

        private IOutgoingService _OutgoingService;
        public OutGoingController(IOutgoingService OutgoingService)
        {
            _OutgoingService = OutgoingService;
        }

        [HttpGet("GetOutgoing")]
        public async Task<LoadResult> GetOutgoing(DataSourceLoadOptionsExtension loadOptions)
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

        [HttpPost("AddDocument")]
        public async Task<IActionResult> AddDocument([FromForm] DcconGoingModel model)
        {
             var queryable = await _blotterMasterService.GetDocInfoQuery();
              queryable.LastNumber += 1;
              model.Reference = "AJES/" + model.Orign + "/" + model.CorresType + "/" + model.FileNo + "/" + queryable.LastNumber;
              model.RefNo = queryable.LastNumber.ToString();

            model.Reference = "Test";
            model.RefNo = "99999";

            var result = await _OutgoingService.AddOutGoing(model);


            if (model.document != null)
            {
              //  var res = await _OutgoingService.ProcessDocument(model.document, queryable.LastNumber.ToString());
               // if (res != null)
               // {
                //    _OutgoingService.UpdateFileName(res, model.Id);

               // }
            }
           // await _blotterMasterService.UpdateDocInfo(queryable);
            return Ok(new { message = model.Reference });


        }
    }
}
