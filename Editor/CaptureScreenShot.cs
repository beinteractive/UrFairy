using System;
using UnityEditor;
using UnityEngine;

namespace UrFairy
{
    public class CaptureScreenShot
    {
        [MenuItem("UrFairy/Capture Screenshot")]
        static void Capture()
        {
            ScreenCapture.CaptureScreenshot($"Screenshot-{DateTime.Now:yyyyMMdd-HHmmss}.png");
        }
    }
}