using DCC.ModelSQL.GenericRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DCC.ModelSQL.GenericRepository.Implementation
{
    public class EntityFrameworkRepositoryReadOnly : IRepositoryReadOnly
    {
        public Task<IEnumerable<T>> CheckNumber<T>(Expression<Func<T, bool>> filter = null) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByRawSql<T>(string sql) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetQueryable<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
