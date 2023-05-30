using DCC.ModelSQL.GenericRepository.Repository;
using DCC.ModelSQL.Models;
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

        private readonly DCCContext _DbContext;
        public EntityFrameworkRepositoryReadOnly(DCCContext context)
        {
            _DbContext = context;

        }
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
            var tt = _DbContext.Set<T>(); //The DbSet instance is created by calling the Set method on the DbContext object by passing the Entity Type as a parameter.
            return tt;
        }
    }
}
