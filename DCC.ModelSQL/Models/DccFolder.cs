using System;
using System.Collections.Generic;

#nullable disable

namespace DCC.ModelSQL.Models
{
    public partial class DccFolder
    {
        public DccFolder()
        {
            DccFolderDetails = new HashSet<DccFolderDetail>();
            DccProjectFolders = new HashSet<DccProjectFolder>();
        }

        public int Id { get; set; }
        public string FolderName { get; set; }

        public virtual ICollection<DccFolderDetail> DccFolderDetails { get; set; }
        public virtual ICollection<DccProjectFolder> DccProjectFolders { get; set; }
    }
}
