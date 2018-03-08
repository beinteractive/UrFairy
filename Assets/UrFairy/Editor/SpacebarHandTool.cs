using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace UrFairy
{
    // Written by @kyubuns
    // https://gist.github.com/kyubuns/04a4b80cfa7cb28d76bd
    [InitializeOnLoad]
    public class SpacebarHandTool
    {
        static SpacebarHandTool()
        {
            // OnGlobalEventHandler
            // from http://anchan828.hatenablog.jp/entry/2013/12/29/015306
            EditorApplication.CallbackFunction function = () => OnGlobalEventHandler(Event.current);
            var info = typeof(EditorApplication).GetField("globalEventHandler",
                BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            if (info != null)
            {
                var functions = (EditorApplication.CallbackFunction) info.GetValue(null);
                functions += function;
                info.SetValue(null, functions);
            }
        }

        private static bool Pressed;
        private static Tool Saved;

        private static void OnGlobalEventHandler(Event e)
        {
            if (!Pressed && e.type == EventType.KeyDown)
            {
                if (e.keyCode == KeyCode.Space)
                {
                    Pressed = true;
                    Saved = Tools.current;
                    Tools.current = Tool.View;
                }
            }

            if (Pressed && e.type == EventType.KeyUp)
            {
                if (e.keyCode == KeyCode.Space)
                {
                    Pressed = false;
                    Tools.current = Saved;
                }
            }
        }
    }
}