using UnityEngine;
using UnityEditor;
using System;

namespace Kohcha.UI
{
    public static partial class KohchaGUI
    {
        public static void DottedBox(Rect rect, Color color, float dashSize = 1f)
        {
            Handles.BeginGUI();
            Handles.color = color;

            Vector3 p1 = new Vector3(rect.x, rect.y);
            Vector3 p2 = new Vector3(rect.xMax, rect.y);
            Vector3 p3 = new Vector3(rect.xMax, rect.yMax);
            Vector3 p4 = new Vector3(rect.x, rect.yMax);

            Handles.DrawDottedLine(p1, p2, dashSize);
            Handles.DrawDottedLine(p2, p3, dashSize);
            Handles.DrawDottedLine(p3, p4, dashSize);
            Handles.DrawDottedLine(p4, p1, dashSize);

            Handles.EndGUI();
        }
    }
}