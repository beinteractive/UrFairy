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

    public static void LocalPosition(this Transform t, System.Func<Vector3, Vector3> f) {
      t.localPosition = f(t.localPosition);
    }

    public static void LocalRotation(this Transform t, System.Func<Quaternion, Quaternion> f) {
      t.localRotation = f(t.localRotation);
    }

    public static void LocalEulerAngles(this Transform t, System.Func<Vector3, Vector3> f) {
      t.localEulerAngles = f(t.localEulerAngles);
    }

    public static void LocalScale(this Transform t, System.Func<Vector3, Vector3> f) {
      t.localScale = f(t.localScale);
    }

    public static void Position(this Transform t, System.Func<Vector3, Vector3> f) {
      t.position = f(t.position);
    }

    public static void Rotation(this Transform t, System.Func<Quaternion, Quaternion> f) {
      t.rotation = f(t.rotation);
    }

    public static void EulerAngles(this Transform t, System.Func<Vector3, Vector3> f) {
      t.eulerAngles = f(t.eulerAngles);
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