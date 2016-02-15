using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS.Core
{
    public sealed class GenericSingleton<T> where T : new()
    {
        private Lazy<T> _objectSingletonInstance= new Lazy<T>(() =>
        {
            var _objectSingleton = new T();
            //do stuff here to build your _objectSingleton
            return _objectSingleton;
        });

        public T OurAwesomeObject
        {
            get { return _objectSingletonInstance.Value; }
        }
    }
}
