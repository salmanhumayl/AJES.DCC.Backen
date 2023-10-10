using DCC.Common.Service;
using System;
using System.Collections.Generic;

#nullable disable

namespace DCC.ModelSQL.Models
{
    public class DccUser : IEntityIdentifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
