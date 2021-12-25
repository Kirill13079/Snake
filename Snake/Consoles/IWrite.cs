using System;

namespace Snake.Consoles
{
    public interface IWrite
    {
        void Write(object value);
        void WriteLine(string message);
    }
}
