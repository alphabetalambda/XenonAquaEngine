namespace XenonAquaEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine.StartupAndShutdown.Start(2000);
            System.Threading.Thread.Sleep(10000);
            Engine.StartupAndShutdown.Stop();
        }
    }
}