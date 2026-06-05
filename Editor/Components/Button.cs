using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

namespace Kohcha.UI
{
    public static partial class KohchaGUI
    {
        private static readonly Dictionary<ValueTuple<Color, int>, GUIStyle> _buttonStyleCache = new();

        public static bool Button(
            string text,
            Action onClick,
            float? width = null,
            float? height = null,
            Color? backgroundColor = null,
            Color? textColor = null,
            Color? borderColor = null,
            float? borderWidth = null,
            int? radius = null
        )
        {
            Color baseColor = backgroundColor ?? KohStyle.ColorScheme.button;
            int r = radius ?? 0;
            GUIStyle style = GetButtonStyle(baseColor, textColor, r);

            // layout build
            var layoutOptions = new List<GUILayoutOption>();
            float h = height ?? 24f;
            layoutOptions.Add(GUILayout.Height(h));
            if (width.HasValue)
            {
                layoutOptions.Add(GUILayout.Width(width.Value));
            }

            bool isClicked = false;

            if (borderColor.HasValue)
            {
                Rect rect = GUILayoutUtility.GetRect(new GUIContent(text), style, layoutOptions.ToArray());

                if (r > 0)
                {
                    GUIStyle borderStyle = KohStyle.GetBoxStyle(borderColor.Value, r);
                    GUI.Box(rect, GUIContent.none, borderStyle);
                }
                else
                {
                    EditorGUI.DrawRect(rect, borderColor.Value);
                }

                float bw = borderWidth ?? 1f;

                int innerRadius = Mathf.Max(0, r - Mathf.RoundToInt(bw));
                GUIStyle innerStyle = GetButtonStyle(baseColor, textColor, innerRadius);

                Rect innerRect = new Rect(
                    rect.x + bw,
                    rect.y + bw,
                    rect.width - (bw * 2),
                    rect.height - (bw * 2)
                );

                isClicked = GUI.Button(innerRect, text, innerStyle);

                EditorGUIUtility.AddCursorRect(innerRect, MouseCursor.Link);

            }
            else
            {
                isClicked = GUILayout.Button(text, style, layoutOptions.ToArray());
                EditorGUIUtility.AddCursorRect(GUILayoutUtility.GetLastRect(), MouseCursor.Link);
            }

            // execution
            if (isClicked && onClick != null)
            {
                onClick.Invoke();
            }

            return isClicked;
        }

        //======================================================
        // ボタンスタイルファクトリーメソッド
        private static GUIStyle GetButtonStyle(
            Color baseColor,
            Color? textColor = null,
            int? radius = null
        )
        {
            // もし同様の組み合わせがあった場合その組み合わせをリターン
            var key = (baseColor, radius ?? 0);
            if (_buttonStyleCache.TryGetValue(key, out GUIStyle style))
            {
                return style;
            }

            // ボタンスタイル
            style = new GUIStyle(GUI.skin.button)
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 12,
                border = new RectOffset(0, 0, 0, 0),
                overflow = new RectOffset(0, 0, 0, 0)
            };

            // 文字色
            Color tColor = textColor ?? Color.white;
            style.normal.textColor = tColor;
            style.hover.textColor = tColor;
            style.active.textColor = tColor;

            // 背景色
            Color hoverColor = Color.Lerp(baseColor, Color.white, 0.2f);
            Color activeColor = Color.Lerp(baseColor, Color.black, 0.2f);

            if (radius.HasValue && radius.Value > 0)
            {
                int r = radius.Value;
                style.normal.background = KohStyle.CreateRoundedTexture(r, baseColor);
                style.hover.background = KohStyle.CreateRoundedTexture(r, hoverColor);
                style.active.background = KohStyle.CreateRoundedTexture(r, activeColor);

                style.border = new RectOffset(r, r, r, r);
            }
            else
            {
                style.normal.background = KohStyle.CreateBackgroundTexture(baseColor);
                style.hover.background = KohStyle.CreateBackgroundTexture(hoverColor);
                style.active.background = KohStyle.CreateBackgroundTexture(activeColor);

                style.border = new RectOffset(0, 0, 0, 0);
            }

            _buttonStyleCache[key] = style;

            return style;
        }
    }
}