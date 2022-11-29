using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenonAquaEngine
{
    internal class EngineConfig
    {
        /// <summary>
        /// the game version number or string
        /// </summary>
        public static string GameVersion = "";
        /// <summary>
        /// the game's menu art. should be formated as {line1, line2, line3 etc.}
        /// </summary>
        public static string[] GameMenuArt = { };
        /// <summary>
        /// the game's credits, should be formated as {{ line 1 letter 1 ,line 1 letter 2,line 1 letter 3, etc.} , { line 2 letter 1, line 2 letter 2, line 2 letter 3, etc.} , etc.} 
        /// </summary>
        public static char[,] GameCredits = { {'X', 'e', 'n', 'o', 'n', ' ', 'A', 'q', 'u', 'a', ' ', 'E', 'n', 'g', 'i', 'n', 'e', } };
        /// <summary>
        /// the name of your game
        /// </summary>
        public static string GameName = "XenonAquaEngine";
    }
}
