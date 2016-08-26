using Serilog;

namespace ProjectC
{
    public class ClassC
    {
        protected ClassC()
        {
            CreateLogger();
        }

        private static void CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                           .MinimumLevel.Verbose()
                           .WriteTo.Console()
                           .CreateLogger();
        }
    }
}
