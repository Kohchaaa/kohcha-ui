using UnityEngine;
using UnityEditor;
using System;

namespace Kohcha.UI
{
    public static partial class KohStyle
    {
        public static class ColorScheme
        {
            public static readonly Color background = new Color(0.15f, 0.15f, 0.15f, 1.0f);
            public static readonly Color surface = new Color(0.21f, 0.21f, 0.21f, 1.0f);
            public static readonly Color button = new Color(0.3f, 0.3f, 0.3f, 1.0f);
            public static readonly Color border = EditorGUIUtility.isProSkin ? new Color(0.35f, 0.35f, 0.35f, 1.0f) : new Color(0.4f, 0.4f, 0.4f, 1.0f);
            public static readonly Color lineColor = EditorGUIUtility.isProSkin ? new Color(0.35f, 0.35f, 0.35f, 1.0f) : new Color(0.4f, 0.4f, 0.4f, 1.0f);
        }
    }
}