using CommandLine;
using System.Threading;
using Tetris.App.Controllers;
using Tetris.Game;
using Tetris.Game.Render;
using Tetris.App.Renderers;
using System;

namespace Tetris.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(Start);
        }

        private static void Start(CommandLineOptions options)
        {
            var renderer = GetRenderer(options.RenderMode, options.Rows, options.Cols);
            var controller = new RandomController(0.05f);

            do
            {
                var game = new TetrisGame(new TetrisConfig { GameWidth = options.Cols, GameHeight = options.Rows }, renderer, controller);
                game.Run();
                Thread.Sleep(1000);
            } while (true);
        }

        private static ITetrisRenderer GetRenderer(RenderMode mode, int rows, int cols)
        {
            switch (mode)
            {
                case RenderMode.Console:
                    return new TetrisConsoleRenderer(cols, rows);
                case RenderMode.LedMatrix:
                    return new LedMatrixRenderer(rows, cols, 25);
                default:
                    throw new Exception("Rendermode not implemented");
            }
        }
    }

    public class CommandLineOptions
    {
        [Option(Required = true)]
        public RenderMode RenderMode { get; set; }

        [Option(Default = 16)]
        public int Rows { get; set; }
        [Option(Default = 32)]
        public int Cols { get; set; }

    }
    public enum RenderMode
    {
        Console,
        LedMatrix
    }
}
