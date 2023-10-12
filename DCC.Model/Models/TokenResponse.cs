using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Model.Models
{
    public class DCCTokenResponse
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
        public string Name  { get; set; }

    }
}
