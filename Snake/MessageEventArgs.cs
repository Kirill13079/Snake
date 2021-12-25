using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class MessageEventArgs
    {
        readonly string _message;

        public MessageEventArgs(string message) =>
            _message = message;

        public string Message => 
            _message;
    }
}
