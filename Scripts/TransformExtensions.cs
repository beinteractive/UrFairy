using UnityEngine;
using System.Collections;

namespace UrFairy {
  public static class TransformExtensions {

    public class Transformation {
      public Vector3 p;
      public Quaternion r;
      public Vector3 s;
    }

    public static void Identity(this Transform t) {
      t.localPosition = Vector3.zero;
      t.localRotation = Quaternion.identity;
      t.localScale = Vector3.one;
    }

    public static void AutoRestore(this Transform t, System.Action f) {
      var r = t.Replicate();
      f();
      t.Restore(r);
    }

    public static Transformation Replicate(this Transform t) {
      var rep = new Transformation();
      rep.p = t.localPosition;
      rep.r = t.localRotation;
      rep.s = t.localScale;
      return rep;
    }

    public static void Restore(this Transform t, Transformation rep) {
      t.localPosition = rep.p;
      t.localRotation = rep.r;
      t.localScale = rep.s;
    }

    public static Transform FindDescendant(this Transform t, string name) {
      var l = t.childCount;
      for (var i = 0; i < l; ++i) {
        var child = t.GetChild(i);
        if (child.name == name) {
          return child;
        }
        var found = child.FindDescendant(name);
        if (found != null) {
          return found;
        }
      }
      return null;
    }
  }
}