using System;
using System.Collections.Generic;
using System.Text;

namespace session09C_
{
    internal class AppLogger
    {
        private static AppLogger? instance = null;

        
        private AppLogger()
        {
            Console.WriteLine("AppLogger instance created.");
        }

        public static AppLogger GetLogger()
        {
            if (instance == null)
            {
                instance = new AppLogger();
            }

            return instance;
        }

        public void Log(string message)
        {
            Console.WriteLine("[LOG]: " + message);
        }
    }
}
