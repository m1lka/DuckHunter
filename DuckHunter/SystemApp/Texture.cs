using System;

using SDL2;
using Image = SDL2.SDL_image;

namespace DuckHunter.SystemApp
{
    public class Texture: ICloneable, IDisposable
    {
        private bool _disposed;
        private IntPtr _texture;

        public IntPtr Handle { get { return _texture; } }

        public Texture()
        {
            _disposed = false;
            _texture = IntPtr.Zero;
        }

        public Texture(Texture texture)
        {
            _texture = texture.Handle;
            _disposed = texture._disposed;
        }

        public void LoadTextureFromBMP(string pathToFile, IntPtr renderer)
        {
            if(_texture != IntPtr.Zero)
                SDL.DestroyTexture(_texture);

            var surface = SDL.LoadBMP(pathToFile);
            if(surface == IntPtr.Zero)
                throw new Exception($"BMP was not loaded. Error: {SDL.GetError()}");

            _texture = SDL.CreateTextureFromSurface(renderer, surface);
            SDL.FreeSurface(surface);
            if(_texture == IntPtr.Zero)
                throw new Exception($"Texture was not create. Error: {SDL.GetError()}");
        }

        public void LoadTextureFromPNG(string pathToFile, IntPtr renderer)
        {
            int initted = Image.IMG_Init(Image.IMG_InitFlags.IMG_INIT_PNG);
            if((initted & (int)Image.IMG_InitFlags.IMG_INIT_PNG) != (int)Image.IMG_InitFlags.IMG_INIT_PNG)
                throw new Exception($"SDL_Image was not initialized (PNG). Error: {SDL.GetError()}");

            var surface = Image.IMG_Load(pathToFile);
            if(surface == IntPtr.Zero)
                throw new Exception($"PNG was not loaded. Error: {SDL.GetError()}");

            _texture = SDL.CreateTextureFromSurface(renderer, surface);
            SDL.FreeSurface(surface);
            if(_texture == IntPtr.Zero)
                throw new Exception($"Texture was not create. Error: {SDL.GetError()}");

            Image.IMG_Quit();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                SDL.DestroyTexture(_texture);
                _disposed = true;
            }
        }

        public object Clone()
        {
            return new Texture() { _disposed = this._disposed, _texture = this._texture };
        }
    }
}