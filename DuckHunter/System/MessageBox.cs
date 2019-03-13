using System;
using SDL2;

namespace DuckHunter.System
{
    public static class MessageBox
    {
        public enum DialogResult
        {
            No = 0,
            Yes = 1
        }

        public static void ShowInfo(string title, string message)
        {
            SDL.MessageBoxButtonData[] buttons = new SDL.MessageBoxButtonData[1]
            { new SDL.MessageBoxButtonData()
                { buttonid = 0, flags = SDL.MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT, text = "I see"}
            };

            SDL.MessageBoxColorScheme colorScheme = new SDL.MessageBoxColorScheme();
            colorScheme.colors = new SDL.MessageBoxColor[5];

            SDL.MessageBoxData msgboxdData = new SDL.MessageBoxData()
            {
                flags = SDL.MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION,
                window = IntPtr.Zero,
                title = title,
                message = message,
                numbuttons = 1,
                buttons = buttons,
                colorScheme = colorScheme
            };

            int buttonID;
            SDL.ShowMessageBox(ref msgboxdData, out buttonID);
        }

        public static DialogResult Show(string title, string message)
        {
            //Answer gettingAnswer;

            SDL.MessageBoxButtonData[] buttons = new SDL.MessageBoxButtonData[2]
            {
                new SDL.MessageBoxButtonData()
                {
                    buttonid = 0,
                    flags = SDL.MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT,
                    text = "No"
                },

                new SDL.MessageBoxButtonData()
                {
                    buttonid = 1,
                    flags = SDL.MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT,
                    text = "Yes"
                }
            };

            SDL.MessageBoxColorScheme colorScheme = new SDL.MessageBoxColorScheme();
            colorScheme.colors = new SDL.MessageBoxColor[5];

            SDL.MessageBoxData msgboxdData = new SDL.MessageBoxData()
            {
                flags = SDL.MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION,
                window = IntPtr.Zero,
                title = title,
                message = message,
                numbuttons = buttons.Length,
                buttons = buttons,
                colorScheme = colorScheme
            };

            int buttonID;
            SDL.ShowMessageBox(ref msgboxdData, out buttonID);

            return (DialogResult)buttonID;
        }
    }

    
}
