using AngularJS.Model.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS.Repository.Generic
{

    public abstract class GenericRepository<T> : IGenericRepository<T>
          where T : BaseEntity
    {

        public GenericRepository()
        {
        }

        public virtual IEnumerable<T> GetAll()
        {
            return null;
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return null;
        }

        public virtual T Add(T entity)
        {
            return default(T);
        }

        public virtual T Delete(T entity)
        {
            return default(T);
        }

        public virtual void Edit(T entity)
        {
        }

        public virtual void Save()
        {
        }

        public T Edit(int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
