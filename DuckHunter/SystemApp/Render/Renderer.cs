using System;
using DuckHunter.SystemApp.Render;
using SDL2;
using static SDL2.SDL.SDL_RendererFlags;

namespace DuckHunter.SystemApp.Render
{
    public class Renderer: IDisposable
    {
        private bool _disposed;
        private IntPtr _handle;
        private IntPtr _windowHandle;

        private RenderRegion _region;
        private readonly int DefaultWidth = 300;
        private readonly int DefaultHeight = 300;

        public IntPtr Handle { get { return _handle; } }

        public RenderRegion Region { get => _region; set => _region = value; }

        public Renderer(IntPtr windowHandle)
        {
            _disposed = false;
            _windowHandle = windowHandle;
            _region = new RenderRegion(DefaultWidth, DefaultHeight);
        }

        public void Initialize()
        {
            _handle = IntPtr.Zero;
            _handle = SDL.CreateRenderer(
                            _windowHandle, 
                            -1, 
                            SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);
            
            if(_handle == IntPtr.Zero)
                throw new ArgumentException($"Renderer was not created. Error: {SDL.GetError()}");

            if(SDL.RenderSetLogicalSize(_handle, _region.Width, _region.Height) < 0)
                throw new ArgumentException($"Cant set logicale size for renderer. Error: {SDL.GetError()}");
        }

        public void RenderTexture(IntPtr texture, SDL.SDL_Rect dstrect)
        {
            SDL.RenderCopy(_handle, texture, IntPtr.Zero, ref dstrect);
        }

        public void RenderTexture(Texture texture, SDL.SDL_Rect dstrect)
        {
            SDL.RenderCopy(_handle, texture.Handle, IntPtr.Zero, ref dstrect);
        }

        public void RenderTexture(IntPtr texture)
        {
            SDL.RenderCopy(_handle, texture, IntPtr.Zero, IntPtr.Zero);
        }

        public void RenderTexture(Texture texture)
        {
            SDL.RenderCopy(_handle, texture.Handle, IntPtr.Zero, IntPtr.Zero);
        }

        public void RenderSprite(Sprite sprite)
        {
            SDL.SDL_Rect rect = sprite.Bound;
            IntPtr texture = sprite.Texture.Handle;
            SDL.RenderCopy(_handle, texture, IntPtr.Zero, ref rect);
        }

        public void Update()
        {
            SDL.RenderPresent(_handle);
        }

        public void Clear()
        {
            SDL.RenderClear(_handle);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                SDL.DestroyRenderer(_handle);
                _disposed = true;
            }
        }
    }
}