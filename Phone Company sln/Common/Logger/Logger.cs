using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logger
{
    public sealed class Logger
    {
        private static readonly object _DOR = new object();
        private static Logger instance;

        private Logger() { }

        public static Logger GetInstance()
        {
            if (instance == null)
                instance = new Logger();
            return instance;
        }

        public void LogWrite(string str)
        {
            lock (_DOR)
            {
                File.WriteAllText("Logger2.txt", DateTime.Now.Millisecond + " --> " + str);
            }
        }
    }
}
