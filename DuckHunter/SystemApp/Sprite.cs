using System;
using System.Collections.Generic;
using System.Text;

using static SDL2.SDL;

namespace DuckHunter.SystemApp
{
    public class Sprite : IDisposable
    {
        private Texture _texture;
        private SDL_Rect _bound;

        public Texture Texture { get => _texture; set => _texture = value; }
        public SDL_Rect Bound { get => _bound; set => _bound = value; }

        private bool _disposed;

        public Sprite(Texture texture, SDL_Rect bound)
        {
            _texture = texture;
            _bound = bound;

            _disposed = false;
        }

        public void Dispose()
        {
            if(!_disposed)
            {
                _texture.Dispose();
                _disposed = true;
            }
        }
    }
}
