using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC.ModelSQL.GenericRepository.Repository
{
    public interface IRepository : IRepositoryReadOnly
    {
        void InsertModel<T>(T model) where T : class;
        void DeleteModel<T>(int modelId) where T : class;
        bool UpdateModel<T>(T model) where T : class;

        Task<int> SaveAsync();

        void ExecuteRowSql(string query);
    }
}
