using UnityEngine;
using System;
using System.Collections;

namespace UrFairy
{
    public static class VectorExtensions
    {
        public static Vector3 X(this Vector3 v, float x)
        {
            v.x = x;
            return v;
        }

        public static Vector3 Y(this Vector3 v, float y)
        {
            v.y = y;
            return v;
        }

        public static Vector3 Z(this Vector3 v, float z)
        {
            v.z = z;
            return v;
        }

        public static Vector3 X(this Vector3 v, Func<float, float> f)
        {
            v.x = f(v.x);
            return v;
        }

        public static Vector3 Y(this Vector3 v, Func<float, float> f)
        {
            v.y = f(v.y);
            return v;
        }

        public static Vector3 Z(this Vector3 v, Func<float, float> f)
        {
            v.z = f(v.z);
            return v;
        }
    }
}