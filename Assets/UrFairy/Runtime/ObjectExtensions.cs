using System;

namespace UrFairy
{
    public static class ObjectExtensions
    {
        public static T IfJust<T>(this T o, Action<T> f)
        {
            if (o != null)
            {
                f(o);
            }

            return o;
        }

        public static T IfNothing<T>(this T o, Action f)
        {
            if (o == null)
            {
                f();
            }

            return o;
        }

        public static T Tap<T>(this T t, Action<T> f)
        {
            f(t);
            return t;
        }
    }
}