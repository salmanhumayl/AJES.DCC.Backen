using System;
using System.Collections.Generic;

#nullable disable

namespace DCC.ModelSQL.Models
{
    public partial class DccProjectFolder
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public int FolderId { get; set; }

        public virtual DccFolder Folder { get; set; }
        public virtual DccProject ProjectCodeNavigation { get; set; }
    }
}
