using DCC.ModelSQL.GenericRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.ModelSQL.GenericRepository.Implementation
{
    public class EntityFrameworkRepository : EntityFrameworkRepositoryReadOnly, IRepository
    {
        public void DeleteModel<T>(int modelId) where T : class
        {
            throw new NotImplementedException();
        }

        public void ExecuteRowSql(string query)
        {
            throw new NotImplementedException();
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
    }
}
