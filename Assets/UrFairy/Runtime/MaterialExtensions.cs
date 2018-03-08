using UnityEngine;
using System;

namespace UrFairy
{
    public static class MaterialExtensions
    {
        public static Material Color(this Material m, Color col)
        {
            m.color = col;
            return m;
        }

        public static Material Color(this Material m, Func<Color, Color> f)
        {
            m.color = f(m.color);
            return m;
        }

        public static Material Color(this Material m, int name, Color col)
        {
            m.SetColor(name, col);
            return m;
        }

        public static Material Color(this Material m, int name, Func<Color, Color> f)
        {
            m.SetColor(name, f(m.GetColor(name)));
            return m;
        }

        public static Material Color(this Material m, string name, Color col)
        {
            m.SetColor(name, col);
            return m;
        }

        public static Material Color(this Material m, string name, Func<Color, Color> f)
        {
            m.SetColor(name, f(m.GetColor(name)));
            return m;
        }

        public static Material Float(this Material m, int name, Func<float, float> f)
        {
            m.SetFloat(name, f(m.GetFloat(name)));
            return m;
        }

        public static Material Float(this Material m, string name, Func<float, float> f)
        {
            m.SetFloat(name, f(m.GetFloat(name)));
            return m;
        }

        public static Material Float(this Material m, int name, float val)
        {
            m.SetFloat(name, val);
            return m;
        }

        public static Material Float(this Material m, string name, float val)
        {
            m.SetFloat(name, val);
            return m;
        }

        public static Material Keyword(this Material m, string name, bool val)
        {
            if (val)
            {
                m.EnableKeyword(name);
            }
            else
            {
                m.DisableKeyword(name);
            }

            return m;
        }

        public static Material Keyword(this Material m, string name, Func<bool, bool> f)
        {
            if (f(m.IsKeywordEnabled(name)))
            {
                m.EnableKeyword(name);
            }
            else
            {
                m.DisableKeyword(name);
            }

            return m;
        }
    }
}