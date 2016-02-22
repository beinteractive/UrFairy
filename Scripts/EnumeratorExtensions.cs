using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UrFairy {
  public static class EnumeratorExtensions {

    public static IEnumerable<T> Enumerable<T>(this T o) {
      yield return o;
    }

    public static IEnumerable<T> AddFirst<T>(this IEnumerable<T> enumerable, T element) {
      yield return element;
      foreach (var e in enumerable) {
        yield return e;
      }
    }

    public static IEnumerable<T> AddLast<T>(this IEnumerable<T> enumerable, T element) {
      foreach (var e in enumerable) {
        yield return e;
      }
      yield return element;
    }
  }
}