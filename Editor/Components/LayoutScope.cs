using UnityEngine;
using UnityEditor;
using System;

namespace Kohcha.UI
{
    public static partial class KohchaGUI
    {
        public static void LayoutScope(float padding, Action content)
        {
            LayoutScope(padding, padding, padding, padding, content);
        }

        public static void LayoutScope(float top, float bottom, float left, float right, Action content)
        {
            using (new EditorGUILayout.VerticalScope())
            {
                GUILayout.Space(top);
                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.Space(left);
                    using (new EditorGUILayout.VerticalScope())
                    {
                        content?.Invoke();
                    }
                    GUILayout.Space(right);
                }
                GUILayout.Space(bottom);
            }
        }
    }
}