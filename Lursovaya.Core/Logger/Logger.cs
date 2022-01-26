using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Core.Logger
{
    public static class Logger
    {
        public static readonly object sync = new object();

        private static void SaveError(string error)
        {
            try
            {
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog);
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.txt",
                "Log", DateTime.Now));
                lock (sync)
                {
                    File.AppendAllText(filename, error, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch
            {
            }
        }
        public static void Error(string error)
        {
            string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] {1}\r\n",
               DateTime.Now, error);
            SaveError(fullText);
          
        }

        public static void Error(Exception ex, string error)
        {
            string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3}\nText: {4}\nStack trace {4}\r\n",
        DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message, error, ex.StackTrace);
            SaveError(fullText);
        }

        public static void Error(Exception ex)
        {
            string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3}\nStack trace {4}\r\n",
        DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message, ex.StackTrace);
            SaveError(fullText);
        }

        public static void Info(string info)
        {

        }
    }
}
