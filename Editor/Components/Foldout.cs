using UnityEngine;
using UnityEditor;


namespace Kohcha.UI
{
    public static partial class KohchaGUI
    {
        //======================================================
        // style
        private static GUIStyle _foldoutStyle;

        private static GUIStyle foldout
        {
            get
            {
                _foldoutStyle = new GUIStyle("ShurikenModuleTitle")
                {
                    font = EditorStyles.boldLabel.font,
                    fontSize = EditorStyles.boldLabel.fontSize,
                    fontStyle = FontStyle.Bold,
                    fixedHeight = 30f,
                    contentOffset = new Vector2(20f, -3f),
                    margin = new RectOffset(0, 0, 0, 0)
                };

                return _foldoutStyle;
            }
        }


        //======================================================
        // component
        public static bool Foldout(string title, bool display)
        {
            return Foldout(title, "", display);
        }

        // liltoon改良foldout
        public static bool Foldout(string title, string help, bool display)
        {
            var rect = GUILayoutUtility.GetRect(16f, foldout.fixedHeight, foldout);
            GUI.Box(rect, new GUIContent(title, help), foldout);

            var e = Event.current;

            var toggleRect = new Rect(rect.x + 4f, rect.y + 6f, 13f, 13f);
            if (e.type == EventType.Repaint)
            {
                EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
            }

            if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
            {
                display = !display;
                e.Use();
            }

            return display;
        }
    }
}