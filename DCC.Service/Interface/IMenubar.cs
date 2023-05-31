using DCC.Model.Models;
using DCC.ModelSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.Service.Interface
{
    public interface IMenubar
    {
        IEnumerable<DccProject> GetMenuBar();

        List<MenuRegister> GetRegister(int FolderID);



    }
}
