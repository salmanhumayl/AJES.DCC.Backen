using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DCC.Model.Models;

namespace DCC.Service.Service
{
    public class MenubarService : IMenubar
    {
        private readonly IRepository _repository;

        public MenubarService(IRepository repository)
        {
            _repository = repository;

        }
        public IEnumerable<DccProject> GetMenuBar()
        {
            var data = _repository.GetQueryable<DccProject>().Include(p => p.DccProjectFolders).ThenInclude(a => a.Folder);
            return data;
        }

        public List<MenuRegister> GetRegister(int FolderID)
        {
            var project = _repository.GetQueryable<DccProject>();
            var pfolder = _repository.GetQueryable<DccProjectFolder>();
            var folders = _repository.GetQueryable<DccFolder>();
            var folderdetail = _repository.GetQueryable<DccFolderDetail>();
            

            var result = (from pp in project
                          join fdd in pfolder on pp.Code equals fdd.ProjectCode
                          join folder in folders on fdd.FolderId equals folder.Id
                          join detail in folderdetail on folder.Id equals detail.FolderId
                          where folder.Id == FolderID
                          select new MenuRegister
                          {
                              Name=pp.Name,
                              FolderName = folder.FolderName,
                              Description = detail.Description,
                              Route=detail.Route

                          }).ToList();

            return result;
        }
    }
}
