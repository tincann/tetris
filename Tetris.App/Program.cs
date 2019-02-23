using CommandLine;
using System.Threading;
using Tetris.App.Controllers;
using Tetris.Game;
using Tetris.Game.Render;
using Tetris.App.Renderers;
using System;
using RGBLedMatrix;

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
            var renderer = GetRenderer(options.RenderMode, options.CanvasWidth, options.CanvasHeight);
            var controller = new RandomController(0.05f);

            do
            {
                var game = new TetrisGame(new TetrisConfig { GameWidth = options.GameWidth, GameHeight = options.GameHeight }, renderer, controller);
                game.Run();
                Thread.Sleep(1000);
            } while (true);
        }

        private static ITetrisRenderer GetRenderer(RenderMode mode, int width, int height)
        {
            switch (mode)
            {
                case RenderMode.Console:
                    return new TetrisConsoleRenderer(width, height);
                case RenderMode.LedMatrix:
                    return new LedMatrixRenderer(width, height, 25);
                default:
                    throw new Exception("Rendermode not implemented");
            }
        }
    }

    public class CommandLineOptions
    {
        [Option(Required = true)]
        public RenderMode RenderMode { get; set; }

        [Option(Default = 32)]
        public int CanvasWidth{ get; set; }
        [Option(Default = 16)]
        public int CanvasHeight { get; set; }

        [Option(Default = 30)]
        public int GameWidth { get; set; }

        [Option(Default = 14)]
        public int GameHeight { get; set; }
        

    }
    public enum RenderMode
    {
        Console,
        LedMatrix
    }
}
