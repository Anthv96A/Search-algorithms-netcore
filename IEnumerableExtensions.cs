using System;
using System.Collections.Generic;
using System.Linq;

namespace Search_algorithms
{
    public static class IEnumerableExtensions
    {
        public static bool TryGetValue<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, out TSource value) 
        {
            try
            {
                value = source.First(predicate);
                return true;
            }
            catch(Exception)
            {
                value = default(TSource);
                return false;
            }
        }
    }
}
