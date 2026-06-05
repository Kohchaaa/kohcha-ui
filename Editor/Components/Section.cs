using UnityEngine;
using UnityEditor;
using System;

namespace Kohcha.UI
{
    public static partial class KohchaGUI
    {
        public static void Section(string text, Action content)
        {
            DarkBox(() =>
            {
                Header(text, isLine: true, bottomPadding: 0);

                LayoutScope(12.0f, 12.0f, 12.0f, 12.0f, () =>
                {
                    content?.Invoke();
                });
            });
        }
    }
}