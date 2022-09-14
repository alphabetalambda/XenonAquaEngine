using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenonAquaEngine
{
    public class Engine
    {
        public static readonly string EngineVersion = "A1.1.0";
        public static readonly string[] EngineName = { @"___  _ _____ _      ____  _      ____  ____  _     ____ ", @"\  \///  __// \  /|/  _ \/ \  /|/  _ \/  _ \/ \ /\/  _ \", @" \  / |  \  | |\ ||| / \|| |\ ||| / \|| / \|| | ||| / \|", @" /  \ |  /_ | | \||| \_/|| | \||| |-||| \_\|| \_/|| |-||", @"/__/\\\____\\_/  \|\____/\_/  \|\_/ \|\____\\____/\_/ \|" };
        public static readonly string logFile = @"./log.log";
        public static int ReadSpeed;
        public class SDKs
        {

        }
        public class StartUp
        {
            /// <summary>
            /// the start function that needs to be ran to properly initalize the engine
            /// </summary>
            /// <param name="ToReadSpeed">The speed that dialoge lines will be writen at</param>
            static public void Start(int ToReadSpeed)
            {
                System.Threading.Thread.CurrentThread.Name = "Main";
                foreach (var item in EngineName)
                {
                    Console.WriteLine(item);
                    System.Threading.Thread.Sleep(5);
                }
                System.Threading.Thread.Sleep(3000);
                Console.Write("loading");
                Debug.Log.Start();
                Console.Write(".");
                Debug.Log.WriteAsThread("Logging started");
                Console.Write(".");
                ReadSpeed = ToReadSpeed;
            }
        }
        public class Debug
        {
            public static bool IsDebug
            {
                get
                {
#if DEBUG
                    return true;
#else
                    return false;
#endif

                }
            }
            public static class Log
            {
                public static StringBuilder LogStringBuilder;
                public static void Start()
                {
                    LogStringBuilder = new StringBuilder();
                }
                /// <summary>
                /// the function to be used for a thread to write to the console 
                /// </summary>
                /// <param name="ToWrite">the text to log to the console</param>
                public static void WriteAsThread(string ToWrite)
                {
                    string ParsedWrite;
                    string ThreadName = System.Threading.Thread.CurrentThread.Name;
                    ParsedWrite = $"[{DateTime.Now:MM-dd-yyyy-h-mm-tt}][{ThreadName}] {ToWrite}";
                    LogStringBuilder.AppendLine(ParsedWrite);
                    File.AppendAllText(logFile, LogStringBuilder.ToString());
                    LogStringBuilder.Clear();
                }
            }
        }
    }
}
