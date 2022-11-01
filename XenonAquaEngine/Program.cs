namespace XenonAquaEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine.StartupAndShutdown.Start();
            while (Engine.ExitGame == false)
            {
                switch (Engine.State)
                {
                    default:
                        Engine.Screen.Write("Invalid engine state");
                        Engine.ExitGame = true;
                        break;
                }
                Engine.SaveSystem.Save();
            }
        }
    }
}