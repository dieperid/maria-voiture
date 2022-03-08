using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_Engine
{
    internal class LogHandler
    {
        string logs = ""; //Contains all logs
        static LogHandler _instance = null; //Instance of singleton class

        /// <summary>
        /// Add a log
        /// </summary>
        /// <param name="toAdd"> Log to add </param>
        public void AddLog(string toAdd)
        {
            logs += toAdd + $" [DD/MM/YYYY]{DateTime.Now}:{DateTime.Now.Millisecond}[HH:MM:SS:MM]\n";
        }

        /// <summary>
        /// Show all logs to the console
        /// </summary>
        public void ShowLogs()
        {
            Console.WriteLine("[SHOWLOGS]");
            Console.WriteLine(logs);
        }

        /// <summary>
        /// Get the instance of this singleton class
        /// </summary>
        /// <returns> Singleton class instance </returns>
        static public LogHandler GetInstance()
        {
            if(_instance == null)
            {
                _instance = new LogHandler();
            }

            return _instance;
        }
    }
}
