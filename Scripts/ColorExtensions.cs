using UnityEngine;
using System.Collections;

namespace UrFairy {
  public static class ColorExtensions {

    public static Color Color(this int n) {
      return (Color)n.Color32();
    }

    public static Color32 Color32(this int n) {
      return new Color32((byte)((n >> 16) & 0xff), (byte)((n >> 8) & 0xff), (byte)((n >> 0) & 0xff), (byte)0xff);
    }

    public static Color R(this Color c, float r) {
      c.r = r;
      return c;
    }

    public static Color G(this Color c, float g) {
      c.g = g;
      return c;
    }

    public static Color B(this Color c, float b) {
      c.b = b;
      return c;
    }

    public static Color A(this Color c, float a) {
      c.a = a;
      return c;
    }
  }
}