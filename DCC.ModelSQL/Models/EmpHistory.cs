using System;
using System.Collections.Generic;

#nullable disable

namespace DCC.ModelSQL.Models
{
    public partial class EmpHistory
    {
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public double? Days { get; set; }
        public DateTime? Date { get; set; }
        public string Project { get; set; }
        public string Remarks { get; set; }
        public string Path { get; set; }
    }
}
