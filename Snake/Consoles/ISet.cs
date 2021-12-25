using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Consoles
{
    interface ISet
    {
        void SetCursorPosition(int left, int top);
        void SetColor(int value);
        void SetWindowSize();
        void SetBufferSize();
        void SetCursorVisible(bool value);
    }
}
