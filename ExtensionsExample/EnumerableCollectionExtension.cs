using System;
using System.Collections.Generic;

namespace NetCore.ExtensionsExample
{
    public static class EnumerableCollectionExtension
    {
        public static IEnumerable<T> GetByPredicate<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T value in source)
            {
                if (predicate(value))
                    yield return value;
            }
        }
    }
}
