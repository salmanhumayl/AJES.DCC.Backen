using System;
using System.Collections.Generic;

#nullable disable

namespace DCC.ModelSQL.Models
{
    public partial class DccOnGoingOld
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Orign { get; set; }
        public string CorresType { get; set; }
        public string FileNo { get; set; }
        public string Reference { get; set; }
        public string Subject { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string Typist { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Path { get; set; }
        public string RefNo { get; set; }
    }
}
