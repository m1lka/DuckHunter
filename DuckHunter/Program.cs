using System;

using SDL2;

namespace DuckHunter
{
    class Program
    {
        static bool run = true;

        static void OnExit(object sender, EventArgs e)
        {
            run = false;
        }

        static void Quit() =>
            run = false;

        static void Main(string[] args)
        {
            SystemApp.Window window = new SystemApp.Window(SDL.WindowFlags.SDL_WINDOW_SHOWN, SDL.SDL_INIT_EVERYTHING, 500, 500, "Duck");
            window.Initialize();

            window.Quit += OnExit;
            
            while(run)
            {
                while (SDL.SDL_PollEvent(out SDL.SDL_Event events) == 1)
                {
                    SystemApp.Input.Update(events);
                    window.Update(events);
                }
            }

            SDL.Quit();
        }
    }
}
