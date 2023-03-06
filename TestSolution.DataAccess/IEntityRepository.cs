using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Entities.Abstract;

namespace TestSolution.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);

        List<T> GetAll(Expression<Func<T, bool>>? filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
        void DeleteAll(IEnumerable<T> entities);
    }
}
