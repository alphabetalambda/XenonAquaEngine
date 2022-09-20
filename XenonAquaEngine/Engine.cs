using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace XenonAquaEngine
{
    public class Engine
    {
        public static readonly string EngineVersion = "A1.1.0";
        public static readonly string[] EngineName = { @"___  _ _____ _      ____  _      ____  ____  _     ____ ", @"\  \///  __// \  /|/  _ \/ \  /|/  _ \/  _ \/ \ /\/  _ \", @" \  / |  \  | |\ ||| / \|| |\ ||| / \|| / \|| | ||| / \|", @" /  \ |  /_ | | \||| \_/|| | \||| |-||| \_\|| \_/|| |-||", @"/__/\\\____\\_/  \|\____/\_/  \|\_/ \|\____\\____/\_/ \|" };
        public static readonly string logFile = @"./log.log";
        public static int ReadSpeed;
        public static Random Rand = new Random();
        public static char RandomChar()
        {
            return (char)Rand.Next('a', 'z');
        }
        public static char RandomCaseChar()
        {
            int CapsInt = Rand.Next(1, 2);
            char charater = RandomChar();
            if (CapsInt == 1)
            {
                charater = char.ToUpper(charater);
                return (charater);
            }
            return (charater);

        }
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
                Debug.Log.WriteAsThread($"ProcessorID: {System.Threading.Thread.GetCurrentProcessorId()}");
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
                public static void Debugmenu()
                {
                    string PROCESSORIDENTIFIER = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
                    string OS = System.Environment.GetEnvironmentVariable("OS");
                    string PROCESSORARCHITECTURE = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
                    Console.Write("PROCESSOR_IDENTIFIER: ");
                    Console.WriteLine(PROCESSORIDENTIFIER);
                    Console.Write("OS: ");
                    Console.WriteLine(OS);
                    Console.Write("PROCESSOR_ARCHITECTURE: ");
                    Console.WriteLine(PROCESSORARCHITECTURE);
                    Console.WriteLine(System.Threading.Thread.CurrentThread.Name);
                }
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
        public class UserInput
        {
            public static int Int32Input(int limitlow, int limithigh)
            {
                Console.WriteLine("Please enter a number:");
                string input;
                input = Console.ReadLine();
                bool canparse;
                int number;
                canparse = int.TryParse(input, out int num);
                int limithighp = limithigh + 1;
                int limitlowp = limitlow + 1;
                if (canparse == true)
                {
                    number = int.Parse(input);
                    if (number < limitlowp - 1)
                    {
                        canparse = false;
                    }
                    if (number > limithighp + 1)
                    {
                        canparse = false;
                    }
                }
                while (canparse == false)
                {
                    Console.WriteLine("Please enter a valid number:");
                    input = Console.ReadLine();
                    canparse = int.TryParse(input, out num);
                    if (canparse == true)
                    {
                        number = int.Parse(input);
                        if (number < limitlowp)
                        {
                            canparse = false;
                        }
                        if (number > limithighp)
                        {
                            canparse = false;
                        }
                    }
                }
                number = int.Parse(input);
                return number;
            }
        }
        public class Screen
        {
            public static void FillScreen()
            {
                int CHeight = Console.WindowHeight;
                int CWidth = Console.WindowWidth;
                for (int Height = 0; Height<CHeight; Height++)
                {
                    for (int Width=0; Width<CWidth; Width++)
                    {
                        Console.Write(RandomCaseChar());
                    }
                }
            }
            /// <summary>
            /// write the text and delay by the read speed
            /// </summary>
            /// <param name="textin">the text to write</param>
            public static void Write(string textin)
            {
                Console.WriteLine(textin);
                System.Threading.Thread.Sleep(ReadSpeed);
            }
            /// <summary>
            /// prints as many lines as the window is tall and then one
            /// </summary>
            public static void Clearscreeen()
            {
                int ConsoleHeight = Console.WindowHeight + 1;
                for (int i = 0; i < ConsoleHeight; i++)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
