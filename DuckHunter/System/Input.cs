using System;
using System.Collections.Generic;
using System.Text;
using SDL2;
using DuckHunter.InputStructs;

namespace DuckHunter.System
{
    public static class Input
    {
        private static KeyboardState _keyboardState;
        public static KeyboardState Keyboard { get => _keyboardState; }

        private static MouseState _mouseState;
        public static MouseState MouseState { get => _mouseState; }

        public static void Update(SDL.SDL_Event currentEvent)
        {
            UpdateMouseState(currentEvent);
            UpdateKeyboardState(currentEvent);
        }

        // TODO should be optimized in future
        private static void UpdateMouseState(SDL.SDL_Event currentEvent)
        {
            //if(currentEvent.type == (SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN | SDL.SDL_EventType.SDL_MOUSEBUTTONUP))
            //{
                SDL.SDL_MouseButtonEvent mouseButtonEvent = currentEvent.button;
                var buttonType = mouseButtonEvent.type;
                var buttonTimestamp = mouseButtonEvent.timestamp;
                var buttonWhich = mouseButtonEvent.which;
                var buttonButton = (MouseButton)mouseButtonEvent.button;
                var buttonState = (MouseButtonState)mouseButtonEvent.state;
                var buttonClicks = (Click)mouseButtonEvent.clicks;
                var buttonPositionX = mouseButtonEvent.x;
                var buttonPositionY = mouseButtonEvent.y;
            //}
            
            //if (currentEvent.type == (SDL.SDL_EventType.SDL_MOUSEWHEEL))
            //{
                SDL.SDL_MouseWheelEvent mouseWheelEvent = currentEvent.wheel;
                var wheelType = mouseWheelEvent.type;
                var wheelTimestamp = mouseWheelEvent.timestamp;
                var wheelWhich = mouseWheelEvent.which;
                var scrollX = mouseWheelEvent.x;
                var scrollY = mouseWheelEvent.y;
                var wheelDirection = mouseWheelEvent.direction;
            //}
            
            //if (currentEvent.type == (SDL.SDL_EventType.SDL_MOUSEMOTION))
            //{
                SDL.SDL_MouseMotionEvent mouseMotionEvent = currentEvent.motion;
                var motionType = mouseMotionEvent.type;
                var motionTimestamp = mouseMotionEvent.timestamp;
                var motionWhich = mouseMotionEvent.which;
                var motionState = mouseMotionEvent.state;
                var motionX = mouseMotionEvent.x;
                var motionY = mouseMotionEvent.y;
                var motionXRel = mouseMotionEvent.xrel;
                var motionYRel = mouseMotionEvent.yrel;
            //}


            _mouseState = new MouseState(
                buttonButton,
                buttonState,
                buttonClicks,
                buttonPositionX,
                buttonPositionY,
                scrollY);
        }

        private static void UpdateKeyboardState(SDL.SDL_Event currentEvent)
        {
            var keyEvent = currentEvent.key;

            var keySym = keyEvent.keysym;
            var modifier = keySym.mod;
            var key = keySym.scancode;

            bool repeat = keyEvent.repeat != 0 ?
                true : false;
            KeyState state = keyEvent.state == 0 ?
                KeyState.Released : KeyState.Pressed;

            uint timestamp = keyEvent.timestamp;
            var type = keyEvent.type;

            _keyboardState = new KeyboardState(
                                modifier,
                                key,
                                repeat,
                                state,
                                timestamp,
                                type);
        }
    }
}
