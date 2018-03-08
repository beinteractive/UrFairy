using UnityEngine;
using System;
using System.Collections;

namespace UrFairy
{
    public static class ColorExtensions
    {
        public static Color Color(this int n)
        {
            return (Color)n.Color32();
        }

        public static Color32 Color32(this int n)
        {
            return new Color32((byte)((n >> 16) & 0xff), (byte)((n >> 8) & 0xff), (byte)((n >> 0) & 0xff), (byte)0xff);
        }

        public static Color R(this Color c, float r)
        {
            c.r = r;
            return c;
        }

        public static Color G(this Color c, float g)
        {
            c.g = g;
            return c;
        }

        public static Color B(this Color c, float b)
        {
            c.b = b;
            return c;
        }

        public static Color A(this Color c, float a)
        {
            c.a = a;
            return c;
        }

        public static Color R(this Color c, Func<float, float> f)
        {
            c.r = f(c.r);
            return c;
        }

        public static Color G(this Color c, Func<float, float> f)
        {
            c.g = f(c.g);
            return c;
        }

        public static Color B(this Color c, Func<float, float> f)
        {
            c.b = f(c.b);
            return c;
        }

        public static Color A(this Color c, Func<float, float> f)
        {
            c.a = f(c.a);
            return c;
        }

        public static HSV HSV(this Color c)
        {
            return (HSV)c;
        }

        public static Color Color(this HSV hsv)
        {
            return (Color)hsv;
        }

        public static HSV H(this HSV hsv, float h)
        {
            hsv.h = h;
            return hsv;
        }

        public static HSV S(this HSV hsv, float s)
        {
            hsv.s = s;
            return hsv;
        }

        public static HSV V(this HSV hsv, float v)
        {
            hsv.v = v;
            return hsv;
        }

        public static HSV A(this HSV hsv, float a)
        {
            hsv.a = a;
            return hsv;
        }

        public static HSV H(this HSV hsv, Func<float, float> f)
        {
            hsv.h = f(hsv.h);
            return hsv;
        }

        public static HSV S(this HSV hsv, Func<float, float> f)
        {
            hsv.s = f(hsv.s);
            return hsv;
        }

        public static HSV V(this HSV hsv, Func<float, float> f)
        {
            hsv.v = f(hsv.v);
            return hsv;
        }

        public static HSV A(this HSV hsv, Func<float, float> f)
        {
            hsv.a = f(hsv.a);
            return hsv;
        }
    }

    public struct HSV
    {
        public float h;
        public float s;
        public float v;
        public float a;

        public static explicit operator HSV(Color c)
        {
            var hsv = new HSV();
            Color.RGBToHSV(c, out hsv.h, out hsv.s, out hsv.v);
            hsv.a = c.a;
            return hsv;
        }

        public static explicit operator Color(HSV hsv)
        {
            var c = Color.HSVToRGB(hsv.h, hsv.s, hsv.v);
            c.a = hsv.a;
            return c;
        }
    }
}