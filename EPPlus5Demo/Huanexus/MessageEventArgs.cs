using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPPlus5Demo.Huanexus
{
    public class MessageEventArgs
    {
        public string Message { get; set; }
        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
