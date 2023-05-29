using System;
using System.Collections.Generic;

#nullable disable

namespace DCC.ModelSQL.Models
{
    public partial class DccProject
    {
        public DccProject()
        {
            DccProjectFolders = new HashSet<DccProjectFolder>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }

        public virtual ICollection<DccProjectFolder> DccProjectFolders { get; set; }
    }
}
