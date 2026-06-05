using UnityEngine;

namespace Kohcha.UI
{
    public static partial class KohStyle
    {
        public static Texture2D CreateBackgroundTexture(float grayscale)
        {
            return CreateBackgroundTexture(grayscale, 1.0f);
        }

        public static Texture2D CreateBackgroundTexture(float grayscale, float a)
        {
            return CreateBackgroundTexture(grayscale, grayscale, grayscale, a);
        }

        public static Texture2D CreateBackgroundTexture(Color color)
        {
            return CreateBackgroundTexture(color.r, color.g, color.b, color.a);
        }

        public static Texture2D CreateBackgroundTexture(float r, float g, float b, float a)
        {
            Texture2D tex = new Texture2D(1, 1);
            tex.SetPixel(0, 0, new Color(r, g, b, a));
            tex.Apply();
            tex.hideFlags = HideFlags.HideAndDontSave;
            
            return tex;
        }
    }
}