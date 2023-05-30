using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DCC.ModelSQL.GenericRepository.Repository
{
    public interface IRepositoryReadOnly
    {
        IQueryable<T> GetQueryable<T>() where T : class;

        IEnumerable<T> GetEnumerable<T>() where T : class;
        Task<IEnumerable<T>> CheckNumber<T>(Expression<Func<T, bool>> filter = null) where T : class;
        Task<IEnumerable<T>> GetByRawSql<T>(string sql) where T : class;

    }
}
