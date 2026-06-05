using UnityEngine;
using System.Collections.Generic;
using System;

namespace Kohcha.UI
{
    public static partial class KohStyle
    {
        private static readonly Dictionary<ValueTuple<Color, int>, GUIStyle> _boxStyleCache = new();

        public static GUIStyle GetBoxStyle(Color color, int radius = 0)
        {
            // C#のタプルを使って、色と半径のセットを「鍵」にする
            var key = (color, radius);

            // すでに同じ組み合わせのスタイルを作ったことがあるかチェック
            if (!_boxStyleCache.TryGetValue(key, out GUIStyle style))
            {
                // なければ新規作成
                style = new GUIStyle(GUI.skin.box);
                style.padding = new RectOffset(10, 10, 10, 10); // デフォルトのパディング

                if (radius > 0)
                {
                    // 角丸あり：テクスチャを錬成して9スライス設定
                    style.normal.background = CreateRoundedTexture(radius, color);
                    style.border = new RectOffset(radius, radius, radius, radius);
                }
                else
                {
                    // 角丸なし：ただのベタ塗りテクスチャ
                    style.normal.background = CreateBackgroundTexture(color);
                    style.border = new RectOffset(0, 0, 0, 0);
                }

                // キャッシュに保存
                _boxStyleCache[key] = style;
            }

            return style;
        }
    }
}