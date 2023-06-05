using DCC.Common.Service;
using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            try
            {
                _DbContext.Set<T>().Add(model);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _DbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool UpdateModel<T>(T model) where T : class
        {
            var id = (model as IEntityIdentifier).Id;
            var oldEntity = _DbContext.Find<T>(id);

            if (oldEntity == null)
                return false; // Update not possible, The entity needs to be updated does not exist.
            var props = model.GetType().GetProperties();
            foreach (PropertyInfo info in props)
            {
                if (info.Name != "Id" && info.Name != "CreatedDate" && info.Name != "CreatedBy")
                {
                    info.SetValue(oldEntity, info.GetValue(model));
                }
            }

            return true;
        }

        public void ExecuteRowSql(string query)
        {
            throw new NotImplementedException();
        }
    }
}
