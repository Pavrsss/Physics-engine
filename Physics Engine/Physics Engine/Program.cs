namespace Physics_Engine
{
    internal static class Program
    {
        // Entry point for the application.
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}