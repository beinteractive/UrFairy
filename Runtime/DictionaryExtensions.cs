using System;
using System.Collections.Generic;

namespace UrFairy
{
    public static class DictionaryExtensions
    {
        public static void Query<K, V>(this Dictionary<K, V> self, K key, Action<V> f) where V : UnityEngine.Object
        {
            var v = default(V);
            if (self.TryGetValue(key, out v))
            {
                if ((UnityEngine.Object) v != (UnityEngine.Object) null)
                {
                    f(v);
                }
            }
        }
        
        public static void QueryObject<K, V>(this Dictionary<K, V> self, K key, Action<V> f)
        {
            var v = default(V);
            if (self.TryGetValue(key, out v))
            {
                if (v != null)
                {
                    f(v);
                }
            }
        }

        public static IEnumerable<V> ActiveValues<K, V>(this Dictionary<K, V> self) where V : UnityEngine.Component
        {
            return self.Values.Actives();
        }

        public static IEnumerable<V> ActiveObjectValues<K, V>(this Dictionary<K, V> self) where V : UnityEngine.Object
        {
            return self.Values.ActiveObjects();
        }
    }
}