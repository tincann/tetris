using System;
using System.Threading;
using CommandLine;

namespace DebugScreen
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(Start);

        }

        private static void Start(CommandLineOptions options)
        {
            var renderer = new DebugRenderer(options.Rows, options.Cols, 25);
            while (true)
            {
                renderer.FillScreen();
                Thread.Sleep(200);
            }
        }

        
        public class CommandLineOptions
        {
            [Option(Default = 16)]
            public int Rows { get; set; }
            [Option(Default = 32)]
            public int Cols { get; set; }

        }
    }
}
