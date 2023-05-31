using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Model.Models
{
   public  class DcconGoingModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Orign { get; set; }
        public string CorresType { get; set; }
        public string FileNo { get; set; }
        public string Reference { get; set; }
        public string Subject { get; set; }
        public string? Address { get; set; }
        public string Typist { get; set; }

        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }


        public string Path { get; set; }
        public string RefNo { get; set; }
        
        public IFormFile document { get; set; }

    }
}
