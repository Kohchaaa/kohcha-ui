using UnityEngine;

namespace Kohcha.UI
{
    public static partial class KohStyle
    {
        public static Texture2D CreateRoundedTexture(int radius, Color color)
        {
            // 半径の2倍のサイズのテクスチャを作る（例：半径6なら 12x12）
            int size = radius * 2;
            Texture2D tex = new Texture2D(size, size);
            tex.hideFlags = HideFlags.HideAndDontSave;
            Color transparent = new Color(0, 0, 0, 0);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    // 中心を (radius, radius) とした時の、各ピクセルの距離を計算
                    float dx = x - radius + 0.5f; // +0.5f はピクセルの中心をとるための微調整
                    float dy = y - radius + 0.5f;

                    // 4つの角の判定
                    // 左下、右下、左上、右上のそれぞれの中心からの距離を測る
                    float cornerX = dx > 0 ? dx : -dx;
                    float cornerY = dy > 0 ? dy : -dy;

                    // 円の方程式で、半径以内なら色を塗り、外なら透明にする
                    if (cornerX * cornerX + cornerY * cornerY <= radius * radius)
                    {
                        tex.SetPixel(x, y, color);
                    }
                    else
                    {
                        tex.SetPixel(x, y, transparent);
                    }
                }
            }
            tex.Apply();
            return tex;
        }
    }
}