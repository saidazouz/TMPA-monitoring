using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMPA_monitoring.Models.Repositories
{
    public interface IMachineRepositories<TEntity>
    {
        IList<TEntity> List();

        TEntity Find(long id);

        void Add(TEntity entity);

        void Update(long Id, TEntity entity);

        void Delete(long id);
    }
}
