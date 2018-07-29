using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.Util
{
    public static class EnumerableExtensions
    {
        public static int IndexOf<T>(this IEnumerable<T> collection, T value)
        {
            return collection.IndexOf(value, null);
        }

        public static int IndexOf<T>(this IEnumerable<T> collection, T value, IEqualityComparer<T> comparer)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
            var found = collection
                .Select((a, i) => new { a, i })
                .FirstOrDefault(x => comparer.Equals(x.a, value));
            return found == null ? -1 : found.i;
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T item in collection)
            {
                action(item);
            }
        }
    }
}
