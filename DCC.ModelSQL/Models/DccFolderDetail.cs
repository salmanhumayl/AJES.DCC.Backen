using System;
using System.Collections.Generic;

#nullable disable

namespace DCC.ModelSQL.Models
{
    public partial class DccFolderDetail
    {
        public int Id { get; set; }
        public int FolderId { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }

        public virtual DccFolder Folder { get; set; }
    }
}
