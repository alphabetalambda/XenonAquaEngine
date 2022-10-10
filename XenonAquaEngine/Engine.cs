using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using NAudio.Codecs;
using NAudio.FileFormats;
using NAudio.Midi;
using NAudio.Mixer;
using Microsoft.VisualBasic;

namespace XenonAquaEngine
{
    public class Engine
    {
        public static readonly string EngineVersion = "A1..0";
        public static readonly string[] EngineName = { @"___  _ _____ _      ____  _      ____  ____  _     ____ ", @"\  \///  __// \  /|/  _ \/ \  /|/  _ \/  _ \/ \ /\/  _ \", @" \  / |  \  | |\ ||| / \|| |\ ||| / \|| / \|| | ||| / \|", @" /  \ |  /_ | | \||| \_/|| | \||| |-||| \_\|| \_/|| |-||", @"/__/\\\____\\_/  \|\____/\_/  \|\_/ \|\____\\____/\_/ \|" };
        public static readonly string logFile = @"./log.log";
        public static int ReadSpeed;
        public class RandomClass
        {
            public static Random Rand = new Random();
            public static bool Randombool()
            {
                if (Rand.Next(0, 2) == 1)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            /// <summary>
            /// Generates a random A to Z char
            /// </summary>
            /// <returns>a random A to Z char</returns>
            public static char RandomChar()
            {
                return (char)Rand.Next('a', 'z');
            }
            /// <summary>
            /// Generates a random A to Z char with a random case
            /// </summary>
            /// <returns>A random A to Z char with a random case</returns>
            public static char RandomCaseChar()
            {
                char charater = RandomChar();
                if (Randombool())
                {
                    charater = char.ToUpper(charater);
                    return (charater);
                }
                return (charater);
            }
            public static string CaseRandomizer(char[] stringin)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var charin in stringin)
                {
                    if (Randombool())
                    {
                        sb.Append(char.ToUpper(charin));
                    }
                    else
                    {
                        sb.Append(charin);
                    }
                }
                return sb.ToString();
            }
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
                Console.WriteLine($"Engine Version: {Engine.EngineVersion}");
                Console.WriteLine("Audio By Naudio");
                System.Threading.Thread.Sleep(3000);
                Console.Write("loading");
                Debug.Log.Start();
                Console.Write(".");
                Debug.Log.WriteAsThread("Logging started");
                Console.Write(".");
                Debug.Log.WriteAsThread($"ProcessorID: {System.Threading.Thread.GetCurrentProcessorId()}");
                Console.Write(".");
                Engine.Threads.StartMusicThread();
                Console.WriteLine();
                
                ReadSpeed = ToReadSpeed;
            }
        }
        public class Threads
        {
            public static void StartMusicThread()
            {
                System.Threading.ThreadStart MusicRef = new(Engine.Sound.MusicThread);
                Console.Write(".");
                System.Threading.Thread MusicThread = new(MusicRef);
                Console.Write(".");
                MusicThread.Start();
                Console.Write(".");
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
        public class UserInput
        {
            public static bool BoolYNInput()
            {
                Console.WriteLine("[Y/N]:");
                string input;
                input = Console.ReadLine();
                bool canpare = false;
                input = input.ToLower();
                //convert answer to something easier to parse
                if (input == "yes")
                {
                    input = "y";
                }
                if (input == "no")
                {
                    input = "n";
                }
                //test if the answer can be parsed
                switch (input){
                    case "n":
                        canpare = true;
                        break;
                    case "y":
                        canpare = true;
                        break;
                    default:
                        canpare = false;
                        break;
                }
                while(canpare == false)
                {
                    Console.WriteLine("please enter a valid answer [Y/N]:");
                    input = Console.ReadLine();
                    //convert answer to something easier to parse
                    if (input == "yes")
                    {
                        input = "y";
                    }
                    if (input == "no")
                    {
                        input = "n";
                    }
                    //test if the answer can be parsed
                    switch (input)
                    {
                        case "n":
                            canpare = true;
                            break;
                        case "y":
                            canpare = true;
                            break;
                        default:
                            canpare = false;
                            break;
                    }
                }
                if(input == "n")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
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
            /// <summary>
            /// fills the screen with random upper and lowercase letters
            /// </summary>
            public static void FillScreen()
            {
                Console.WriteLine();
                int CHeight = Console.WindowHeight;
                int CWidth = Console.WindowWidth;
                for (int Height = 0; Height<CHeight; Height++)
                {
                    for (int Width=0; Width<CWidth; Width++)
                    {
                        Console.Write(Engine.RandomClass.RandomCaseChar());
                    }
                }
            }
            /// <summary>
            /// places a blank line
            /// </summary>
            public static void BlankLine()
            {
                Console.WriteLine();
            }
            /// <summary>
            /// write the text and delay by the defined write speed
            /// </summary>
            /// <param name="textin">the text to write</param>
            /// <param name="writespeed">the time to wait after</param>
            /// <exception cref="ArgumentException"></exception>
            public static void CustomSpeedWrite(string textin, int writespeed)
            {
                if (string.IsNullOrWhiteSpace(textin))
                {
                    throw new ArgumentException($"'{nameof(textin)}' cannot be null or whitespace.", nameof(textin));
                }
                Console.WriteLine(textin);
                System.Threading.Thread.Sleep(writespeed);
            }
            /// <summary>
            /// write the text and delay by the read speed
            /// </summary>
            /// <param name="textin">the text to write</param>
            public static void Write(string textin)
            {
                if (string.IsNullOrWhiteSpace(textin))
                {
                    throw new ArgumentException($"'{nameof(textin)}' cannot be null or whitespace.", nameof(textin));
                }

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
            public static void DrawMenu()
            {
                if (Engine.Debug.IsDebug)
                {
                    Engine.Debug.Debugmenu();
                }
                foreach(var line in EngineConfig.GameMenuArt)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public class Sound
        {
            private static readonly string SoundsFolder = "./Sounds";
            /// <summary>
            /// name of the song in the sounds directory
            /// </summary>
            public static string SongName = "theme.wav";
            public static System.TimeSpan SongLength = new System.TimeSpan(0,0,59);
            private static WaveOutEvent MusicOut = new WaveOutEvent();
            private static WaveFileReader MusicReader = new WaveFileReader(SoundsFolder + "/" + SongName);
            public static int MusicIntent = 1;
            public static void MusicThread()
            {
                Thread.CurrentThread.Name = "Music Thread";
                if (Debug.IsDebug)
                {
                    Console.WriteLine("music thread started");
                    Debug.Log.WriteAsThread("music thread started");
                }
                while (true)
                {
                    if (MusicReader.CurrentTime == SongLength)
                    {
                        MusicIntent = 2;
                    }
                    switch (MusicIntent)
                    {
                        case 0:
                            break;
                        case 1:
                            MusicOut.Init(MusicReader);
                            MusicIntent = 0;
                            MusicOut.Play();
                            break;
                        case 2:
                            MusicReader.Seek(0, 0);
                            MusicIntent = 0;
                            break;
                        case 3:
                            MusicReader.Skip(100);
                            MusicIntent = 0;
                            break;
                    }
                }
            }
        }
    }
}
