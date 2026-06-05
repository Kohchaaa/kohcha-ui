using UnityEngine;
using UnityEditor;
using System;

namespace Kohcha.UI
{
    public static partial class KohchaGUI
    {
        public static void FillBackground(EditorWindow window, Color color)
        {
            Rect bgRect = new Rect(0, 0, window.position.width, window.position.height);
            EditorGUI.DrawRect(bgRect, color);
        }
    }
}