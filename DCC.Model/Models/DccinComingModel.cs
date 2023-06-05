using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Model.Models
{
    public class DccinComingModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime? Date { get; set; }
        public string From { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Distribution { get; set; }
        public string FileRef { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string RefNo { get; set; }

        public IFormFile document { get; set; }
    }
}
