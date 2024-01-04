using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHE2.Contratcs
{
    public interface IGeneralRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByGuid(Guid guid);
        TEntity Create(TEntity obj);
        bool Update(TEntity obj);
        bool Delete(TEntity obj);
        void Clear();
    }
}
