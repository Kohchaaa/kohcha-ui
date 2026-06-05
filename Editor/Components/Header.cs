using UnityEngine;
using UnityEditor;

namespace Kohcha.UI
{
    public static partial class KohchaGUI
    {
        private static GUIStyle _headerStyle;
        private static GUIStyle HeaderStyle => _headerStyle ??= CreateHeaderStyle();

        private static GUIStyle CreateHeaderStyle()
        {
            GUIStyle style = new GUIStyle(EditorStyles.boldLabel)
            {
                fontSize = 13,
            };

            return style;
        }

        public static void Header(string text, bool isLine = false, float bottomPadding = 3f)
        {
            LayoutScope(2, 2, 6, 6, () =>
            {
                GUILayout.Label(text, HeaderStyle);
            });

            if(isLine) Separator(weight: 2, padding: 2);

            if (bottomPadding > 0)
            {
                GUILayout.Space(bottomPadding);
            }
        }
    }
}