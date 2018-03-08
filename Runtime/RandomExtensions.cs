using UnityEngine;
using System.Collections;

namespace UrFairy
{
    public static class RandomExtensions
    {
        public static int RandomSign(this int n)
        {
            return n * (Random.value <= 0.5f ? 1 : -1);
        }

        public static float RandomSign(this float n)
        {
            return n * (Random.value <= 0.5f ? 1f : -1f);
        }
    }
}