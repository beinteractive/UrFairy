using UnityEngine;
using System.Collections;

namespace UrFairy {
	public static class MonoBehaviourExtensions {

		public static void Delay(this MonoBehaviour g, System.Action f) {
			Delay(g, 1, f);
		}

		public static void Delay(this MonoBehaviour g, int frames, System.Action f) {
			g.StartCoroutine(DelayCoroutine(frames, f));
		}

		public static void Delay(this MonoBehaviour g, float seconds, System.Action f) {
			g.StartCoroutine(DelayCoroutine(seconds, f));
		}

		public static IEnumerator DelayCoroutine(int frames, System.Action f) {
			for (var n = 0; n < frames; ++n) {
				yield return null;
			}
			f();
		}

		public static IEnumerator DelayCoroutine(float seconds, System.Action f) {
			yield return new WaitForSeconds(seconds);
			f();
		}

	}
}