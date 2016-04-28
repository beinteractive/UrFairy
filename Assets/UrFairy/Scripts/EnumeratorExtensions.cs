using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UrFairy
{
    public static class EnumeratorExtensions
    {
        public static IEnumerable<T> Enumerable<T>(this T o)
        {
            yield return o;
        }

        public static IEnumerable<T> AddFirst<T>(this IEnumerable<T> enumerable, T element)
        {
            yield return element;
            foreach (var e in enumerable)
            {
                yield return e;
            }
        }

        public static IEnumerable<T> AddLast<T>(this IEnumerable<T> enumerable, T element)
        {
            foreach (var e in enumerable)
            {
                yield return e;
            }
            yield return element;
        }

        public static void Each<T>(this IEnumerable<T> enumerable, System.Action<T> f)
        {
            foreach (var e in enumerable)
            {
                f(e);
            }
        }

        public static void EachWithIndex<T>(this IEnumerable<T> enumerable, System.Action<T, int> f)
        {
            EachWithIndex(enumerable, 0, f);
        }

        public static void EachWithIndex<T>(this IEnumerable<T> enumerable, int start, System.Action<T, int> f)
        {
            var list = new List<T>(enumerable);
            var l = list.Count;
            for (var i = 0; i < l; ++i)
            {
                f(list[i], start + i);
            }
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> self)
        {
            return self.OrderBy(e => e, new RandomComparer<T>());
        }

        class RandomComparer<T> : IComparer<T>
        {
            public int Compare(T a, T b)
            {
                return 1 - 2 * Random.Range(0, 1);
            }
        }

        public static T Sample<T>(this IEnumerable<T> self)
        {
            return self.ElementAt(Random.Range(0, self.Count()));
        }
    }
}