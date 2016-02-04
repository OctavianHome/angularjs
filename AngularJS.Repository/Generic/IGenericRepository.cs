using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AngularJS.Model.Generic;

namespace AngularJS.Repository.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        T Edit(int entityId);
        void Edit(T entity);
        void Save();
    }
}
