using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UrFairy
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this List<T> list)
        {
            list.Sort((a, b) =>
            {
                return 1 - 2 * Random.Range(0, 1);
            });
        }
    }
}