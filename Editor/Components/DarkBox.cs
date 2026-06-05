using UnityEngine;
using UnityEditor;
using System;

namespace Kohcha.UI
{
    public static partial class KohchaGUI
    {
        //======================================================
        // 高さ可変
        public static void DarkBox(Action content)
        {
            using (new EditorGUILayout.VerticalScope(KohStyle.GetBoxStyle(KohStyle.ColorScheme.surface, 0)))
            {
                content?.Invoke();
            }
        }

        //======================================================
        // Rect指定
        public static void DrawDarkBox(Rect rect)
        {
            GUI.Box(rect, GUIContent.none, KohStyle.GetBoxStyle(KohStyle.ColorScheme.surface, 0));
        }
    }
}