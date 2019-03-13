using System;
using System.Collections.Generic;
using System.Text;

namespace DuckHunter.SystemApp
{
    public static class TextureFactory
    {
        private static Dictionary<uint, Texture> _textureDict = new Dictionary<uint, Texture>();

        public static void InitFactory(IntPtr rendererHandle)
        {
            // EXAMPLE: string cellPath = @"Content\Textures\cell.png";
        }

        public static Texture GetTexture(uint ID)
        {
            return new Texture();
        }
    }
}
