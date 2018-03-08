using UnityEngine;
using System;

namespace UrFairy
{
    public static class MaterialExtensions
    {
        public static Material Color(this Material m, Func<Color, Color> f)
        {
            m.color = f(m.color);
            return m;
        }
    }
}

