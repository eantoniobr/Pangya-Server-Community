using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.Utilities.Log
{
    public enum type_msg : int
    {
        CL_ONLY_CONSOLE,
        CL_FILE_TIME_LOG_AND_CONSOLE,
        CL_FILE_LOG_AND_CONSOLE,
        CL_ONLY_FILE_LOG,
        CL_ONLY_FILE_TIME_LOG,
        CL_ONLY_FILE_LOG_IO_DATA,
        CL_FILE_LOG_IO_DATA_AND_CONSOLE,
        CL_ONLY_FILE_LOG_TEST,
        CL_FILE_LOG_TEST_AND_CONSOLE,
    };
    public class Message : IDisposable
    {
        public Message()
        { }

        public Message(string s, type_msg _tipo = 0)
        {
            m_message = s;
            m_tipo = (type_msg)_tipo;
            var time = DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss]");
            m_message = time + " " + m_message;
        }

        public void append(string s)
        {
            m_message += s;
        }
        public void set(string s)
        {
            m_message = s;
        }

        public string get() => m_message;
        public type_msg getTipo() => m_tipo;


        private string m_message;
        type_msg m_tipo;

        public void Dispose()
        {
            if (!string.IsNullOrEmpty(m_message))
            {
                m_message = "";
            }
        }
    }


    public static class Message_Pool
    {
        static readonly List<Message> m_message = new List<Message>();
        private static void LogOnly()
        {
            var _local = System.IO.Directory.GetCurrentDirectory() + "\\log";
            if (System.IO.Directory.Exists(_local) == false)
            {
                System.IO.Directory.CreateDirectory(_local);

            }
            var _file = System.IO.Directory.GetCurrentDirectory() + "\\log\\log.log";
            var m = getMessage();
            using (System.IO.StreamWriter w = System.IO.File.AppendText(_file))
            {
                w.WriteLine(m.get());
            }
        }

        private static void LogAndConsole()
        {
            LogOnly();
            console_log();
        }

        static void console_log()
        {
            Message m = getMessage();

            if (m != null)
            {

                Console.WriteLine(m.get());
            }
            else
                throw new Exception("Message is null. message_pool::console_log()");
        }
        public static void push(string s, type_msg _tipo = 0)
        {
            push(new Message(s, _tipo));
        }
        public static void push(Message m)
        {
            m_message.Add(m);


            switch (m.getTipo())
            {
                case type_msg.CL_FILE_LOG_AND_CONSOLE:
                    LogAndConsole();
                    break;
                case type_msg.CL_ONLY_CONSOLE:
                    console_log();
                    break;
                case type_msg.CL_FILE_TIME_LOG_AND_CONSOLE:
                    break;
                case type_msg.CL_ONLY_FILE_LOG:
                    LogOnly();
                    break;
                case type_msg.CL_ONLY_FILE_TIME_LOG:
                    break;
                case type_msg.CL_ONLY_FILE_LOG_IO_DATA:
                    break;
                case type_msg.CL_FILE_LOG_IO_DATA_AND_CONSOLE:
                    break;
                case type_msg.CL_ONLY_FILE_LOG_TEST:
                    break;
                case type_msg.CL_FILE_LOG_TEST_AND_CONSOLE:
                    break;
                default:
                    break;
            }
            m_message.Clear();
        }
        static Message getMessage() { return getFirstMessage(); }

        static Message getFirstMessage() { return m_message[0]; }
    }
}
