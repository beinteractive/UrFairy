using UnityEngine;
using System;

namespace UrFairy
{
    public static class RendererExtensions
    {
        public static Renderer Material(this Renderer r, Func<Material, Material> f)
        {
            r.material = f(r.material);
            return r;
        }

        public static Renderer Materials(this Renderer r, Func<Material, Material> f)
        {
            var materials = r.materials;
            for (var i = 0; i < materials.Length; ++i)
            {
                materials[i] = f(materials[i]);
            }
            r.materials = materials;
            return r;
        }
    }
}

