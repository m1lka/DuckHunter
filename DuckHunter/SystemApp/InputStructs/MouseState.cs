using System;
using System.Collections.Generic;
using System.Text;

namespace DuckHunter.InputStructs
{
    public enum MouseButtonState
    {
        Pressed = 0,
        Released = 1
    }

    public enum Click
    {
        Single = 1,
        Double = 2
    }

    public enum MouseButton
    {
        Left = 1,
        Middle = 2,
        Right = 3,
        X1 = 4,
        X2 = 5
    }

    public struct MouseState
    {
        public MouseButton Button { get; }
        public MouseButtonState ButtonState { get; }
        public Click Click { get; }
        public int PositionX { get; }
        public int PositionY { get; }
        public int Scroll { get; }

        public MouseState(
            MouseButton buttonButton,
            MouseButtonState buttonState, 
            Click buttonClicks, 
            int buttonPositionX, 
            int buttonPositionY, 
            int scrollY)
        {
            Button = buttonButton;
            ButtonState = buttonState;
            Click = buttonClicks;
            PositionX = buttonPositionX;
            PositionY = buttonPositionY;
            Scroll = scrollY;
        }
    }
}
