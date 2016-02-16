using UnityEngine;
using System.Collections;

namespace UrFairy {
  public static class ObjectExtensions {
    
    public static T Tap<T>(this T t, System.Action<T> f) {
      f(t);
      return t;
    }
  }
}