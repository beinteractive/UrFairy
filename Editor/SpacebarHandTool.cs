using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Reflection;

namespace UrFairy {
	// Written by @kyubuns
	// https://gist.github.com/kyubuns/04a4b80cfa7cb28d76bd
	[InitializeOnLoad]
	public class SpacebarHandTool {
		static SpacebarHandTool() {
			// OnGlobalEventHandler
			// from http://anchan828.hatenablog.jp/entry/2013/12/29/015306
			EditorApplication.CallbackFunction function = () => OnGlobalEventHandler(Event.current);
			FieldInfo info = typeof(EditorApplication).GetField("globalEventHandler", BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
			EditorApplication.CallbackFunction functions = (EditorApplication.CallbackFunction)info.GetValue(null);
			functions += function;
			info.SetValue(null, (object)functions);
		}

		private static bool pressed;
		private static Tool saved;

		public static void OnGlobalEventHandler(Event e) {
			if (!pressed && e.type == EventType.KeyDown) {
				if (e.keyCode == KeyCode.Space) {
					pressed = true;
					saved = Tools.current;
					Tools.current = Tool.View;
				}
			}
			if (pressed && e.type == EventType.KeyUp) {
				if (e.keyCode == KeyCode.Space) {
					pressed = false;
					Tools.current = saved;
				}
			}
		}
	}
}