using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace EPPlus5Demo.Huanexus
{
    public class MessageLogger
    {
        public TextBoxBase LogBox { get; set; }
        public event EventHandler<MessageEventArgs> Send;

        private string m_StringTemplate = "{0:yyyy-MM-dd HH:mm:ss.fff}, {1}";
        
        public MessageLogger()
        {
            LogBox = null;
            Send += Log_Send;
        }
        public MessageLogger(TextBoxBase logBox)
        {
            LogBox = logBox;
            Send += Log_Send;
        }

        private string LayoutMessage(string message)
        {
            return string.Format(m_StringTemplate, DateTime.Now, message);
        }

        private void Log_Send(object sender, MessageEventArgs e)
        {
            string inMessage = e.Message;
            string message = LayoutMessage(inMessage);
            
            if(LogBox != null)
            {
                if(LogBox.InvokeRequired)
                {
                    LogBox.Invoke(new Action(() =>
                    {
                        LogBox.Text = message + Environment.NewLine + LogBox.Text;
                    }));
                }
                else
                {
                    LogBox.Text = message + Environment.NewLine + LogBox.Text;
                }                
            }
        }

        internal void OnMessage(object p)
        {
            if(Send != null)
            {
                Send(this, new MessageEventArgs(p.ToString()));
            }
        }
    }
}
