using System;
using SDL2;

namespace DuckHunter.System
{
    public class Window: IDisposable
    {
        private bool _disposed;

        private int _width;
        private int _height;
        private UInt32 _systemFlag;
        private SDL.WindowFlags _windowFlag;

        private IntPtr _window;
        private string _title;

        public IntPtr Handle { get { return _window; } }

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public event EventHandler Quit = delegate { };

        public Window(SDL.WindowFlags windowFlag, uint systemFlag, int width, int height, string title)
        {
            _disposed = false;
            _width = width;
            _height = height;
            _systemFlag = systemFlag;
            _windowFlag = windowFlag;
            _title = title;
        }

        public void Initialize()
        {
            _window = IntPtr.Zero;
            if (SDL.Init(_systemFlag) != 0)
                throw new Exception($"Window was not initialized. Error: {SDL.GetError()}");

            CreateWindow();
        }

        private void CreateWindow()
        {
            _window = SDL.CreateWindow(
                _title,
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                _width, _height,
                _windowFlag);

            if (_window == IntPtr.Zero)
                throw new Exception($"Window was not openned. Error: {SDL.GetError()}");
        }

        internal void Update(SDL.SDL_Event currentEvent)
        {
            var windowEvent = currentEvent.window;
            _width = windowEvent.data1;
            _height = windowEvent.data2;

            if (currentEvent.quit.type == SDL.SDL_EventType.SDL_QUIT ||
                currentEvent.key.keysym.scancode == SDL.SDL_Scancode.SDL_SCANCODE_ESCAPE)
                Quit(this, new EventArgs());
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                SDL.DestroyWindow(_window);
                _disposed = true;
            }
        }
    }
}