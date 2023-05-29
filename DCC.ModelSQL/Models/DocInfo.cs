using System;
using System.Collections.Generic;

#nullable disable

namespace DCC.ModelSQL.Models
{
    public partial class DocInfo
    {
        public int Id { get; set; }
        public string Project { get; set; }
        public string DocCode { get; set; }
        public int? LastNumber { get; set; }
    }
}
