using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Common.Service
{
    public interface IEntityIdentifier
    {
        [NotMapped]
        int Id { get; set; }
    }
}
