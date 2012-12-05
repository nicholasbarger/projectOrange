using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projectOrange.BusinessDataLogic
{
    public abstract class Mapper<T, T1> where T1 : new()
    {
        public abstract T1 Map(T t);

        public IEnumerable<T1> Map(IEnumerable<T> coll)
        {
            var list = new List<T1>();

            foreach (var t in coll)
            {
                list.Add(Map(t));
            }

            return list;
        }
    }
}
