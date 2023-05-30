using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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
    }
}
