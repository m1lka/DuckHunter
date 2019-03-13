using System;
using System.Collections.Generic;
using System.Text;
using SDL2;

namespace DuckHunter.InputStructs
{
    public enum KeyState
    {
        Pressed = 0,
        Released = 1
    }

    public struct KeyboardState
    {
        public SDL.SDL_Keymod Modifier { get; }
        public SDL.SDL_Scancode Key { get; }
        public bool Repeat { get; }
        public KeyState State { get; }
        public uint Timestamp { get; }
        public SDL.SDL_EventType Type { get; }

        public KeyboardState(
            SDL.SDL_Keymod modifier,
            SDL.SDL_Scancode key, bool repeat, 
            KeyState state, uint timestamp, 
            SDL.SDL_EventType type)
        {
            Modifier = modifier;
            Key = key;
            Repeat = repeat;
            State = state;
            Timestamp = timestamp;
            Type = type;
        }
    }
}
