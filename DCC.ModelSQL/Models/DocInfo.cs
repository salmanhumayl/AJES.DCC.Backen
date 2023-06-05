using DCC.Common.Service;
using System;
using System.Collections.Generic;

#nullable disable

namespace DCC.ModelSQL.Models
{
    public class DocInfo : IEntityIdentifier
    {
        public int Id { get; set; }
        public string Project { get; set; }
        public string DocCode { get; set; }
        public int? LastNumber { get; set; }
    }
}
