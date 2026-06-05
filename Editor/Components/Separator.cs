using UnityEngine;
using UnityEditor;

namespace Kohcha.UI
{
    public static partial class KohchaGUI
    {
        public static void Separator(float weight = 1.0f, float padding = 0f, Color? color = null)
        {
            Color drawColor = color ?? KohStyle.ColorScheme.lineColor;

            if (padding > 0) GUILayout.Space(padding);

            EditorGUI.DrawRect(EditorGUI.IndentedRect(EditorGUILayout.GetControlRect(false, weight)), drawColor);

            if (padding > 0) GUILayout.Space(padding);
        }

        public static void VerticalSeparator(float weight = 1.0f, float padding = 0f, Color? color = null)
        {
            Color drawColor = color ?? KohStyle.ColorScheme.lineColor;
            
            if (padding > 0) GUILayout.Space(padding);

            Rect rect = GUILayoutUtility.GetRect(
                weight, 
                0f, 
                GUILayout.Width(weight), 
                GUILayout.ExpandHeight(true)
            );
            
            EditorGUI.DrawRect(rect, drawColor);

            if (padding > 0) GUILayout.Space(padding);
        }
    }
}