using System;
using UnityEngine;

namespace UrFairy
{
    public static class ColorExtensions
    {
        public static Color Color(this int n)
        {
            return n.Color32();
        }

        public static Color32 Color32(this int n)
        {
            return new Color32((byte) ((n >> 16) & 0xff), (byte) ((n >> 8) & 0xff), (byte) ((n >> 0) & 0xff), 0xff);
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
            return (HSV) c;
        }

        public static Color Color(this HSV hsv)
        {
            return (Color) hsv;
        }

        public static HSV H(this HSV hsv, float h)
        {
            hsv.H = h;
            return hsv;
        }

        public static HSV S(this HSV hsv, float s)
        {
            hsv.S = s;
            return hsv;
        }

        public static HSV V(this HSV hsv, float v)
        {
            hsv.V = v;
            return hsv;
        }

        public static HSV A(this HSV hsv, float a)
        {
            hsv.A = a;
            return hsv;
        }

        public static HSV H(this HSV hsv, Func<float, float> f)
        {
            hsv.H = f(hsv.H);
            return hsv;
        }

        public static HSV S(this HSV hsv, Func<float, float> f)
        {
            hsv.S = f(hsv.S);
            return hsv;
        }

        public static HSV V(this HSV hsv, Func<float, float> f)
        {
            hsv.V = f(hsv.V);
            return hsv;
        }

        public static HSV A(this HSV hsv, Func<float, float> f)
        {
            hsv.A = f(hsv.A);
            return hsv;
        }
    }

    public struct HSV
    {
        public float H;
        public float S;
        public float V;
        public float A;

        public static explicit operator HSV(Color c)
        {
            var hsv = new HSV();
            Color.RGBToHSV(c, out hsv.H, out hsv.S, out hsv.V);
            hsv.A = c.a;
            return hsv;
        }

        public static explicit operator Color(HSV hsv)
        {
            var c = Color.HSVToRGB(hsv.H, hsv.S, hsv.V);
            c.a = hsv.A;
            return c;
        }
    }
}