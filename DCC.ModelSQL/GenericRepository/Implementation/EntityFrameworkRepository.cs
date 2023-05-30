using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.ModelSQL.GenericRepository.Implementation
{
    public class EntityFrameworkRepository : EntityFrameworkRepositoryReadOnly, IRepository
    {
        private readonly DCCContext _DbContext;
        public EntityFrameworkRepository(DCCContext context) : base(context)
        {
            _DbContext = context;
            
        }
        public void DeleteModel<T>(int modelId) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetModelAsync<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetModelByIdAsync<T>(int modelId) where T : class
        {
            return await _DbContext.Set<T>().FindAsync(modelId);
        }

        public void InsertModel<T>(T model) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public bool UpdateModel<T>(T model) where T : class
        {
            throw new NotImplementedException();
        }

        public void ExecuteRowSql(string query)
        {
            throw new NotImplementedException();
        }
    }
}
