using CommandLine;
using System.Threading;
using Tetris.App.Controllers;
using Tetris.Game;
using Tetris.Game.Render;
using Tetris.App.Renderers;
using System;
using RGBLedMatrix;
using Tetris.Game.Controls;

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
            var renderer = GetRenderer(options);
            var controller = options.Bot ? (ITetrisController)new RandomController(0.05f) : new TetrisConsoleController();

            do
            {
                var game = new TetrisGame(new TetrisConfig { GameWidth = options.GameWidth, GameHeight = options.GameHeight }, renderer, controller);
                game.Run();
                Thread.Sleep(1000);
            } while (true);
        }

        private static ITetrisRenderer GetRenderer(CommandLineOptions options)
        {
            switch (options.RenderMode)
            {
                case RenderMode.Console:
                    return new TetrisConsoleRenderer(options.CanvasWidth, options.CanvasHeight);
                case RenderMode.LedMatrix:
                    return new LedMatrixRenderer(
                        options.CanvasWidth, 
                        options.CanvasHeight, 
                        options.LedBrightness, 
                        options.LedMultiplexing, 
                        options.LedScanMode,
                        options.LedPwmLsbNanoSeconds,
                        options.LedPwmBits,
                        options.LedPwmDither,
                        options.LedPixelMapper
                    );
                default:
                    throw new Exception("Rendermode not implemented");
            }
        }
    }

    public class CommandLineOptions
    {
        [Option(Default = false, HelpText = "Game is automatically played by a bot")]
        public bool Bot { get; set; }

        [Option(Required = true)]
        public RenderMode RenderMode { get; set; }

        [Option(Default = 30)]
        public int GameWidth { get; set; }

        [Option(Default = 14)]
        public int GameHeight { get; set; }

        [Option(Default = 32)]
        public int CanvasWidth { get; set; }
        [Option(Default = 16)]
        public int CanvasHeight { get; set; }


        [Option(Default = 0, HelpText = "--led-scan-mode=<0..1>    : 0 = progressive; 1 = interlaced (Default: 0).")]
        public int LedScanMode { get; set; }

        [Option(Default = 25, HelpText = "--led-brightness=<percent>: Brightness in percent (Default: 25).")]
        public int LedBrightness { get; set; }

        [Option(Default = 0, HelpText = "--led-multiplexing=<0..9> : Mux type: 0=direct; 1=Stripe; 2=Checkered; 3=Spiral; 4=ZStripe; 5=ZnMirrorZStripe; 6=coreman; 7=Kaler2Scan; 8=ZStripeUneven; 9=P10-128x4-Z (Default: 0)")]
        public int LedMultiplexing { get; set; }

        [Option(Default = 130, HelpText = "--led-pwm-lsb-nanoseconds : PWM Nanoseconds for LSB (Default: 130)")]
        public int LedPwmLsbNanoSeconds { get; set; }

        [Option(Default = 11, HelpText = "--led-pwm-bits=<1..11>    : PWM bits (Default: 11).")]
        public int LedPwmBits { get; set; }
        
        [Option(Default = 0, HelpText = "--led-pwm-dither-bits=<0..2> : Time dithering of lower bits (Default: 0)")]
        public int LedPwmDither { get; set; }

        [Option(Default = "", HelpText = "--led-pixel-mapper        : Semicolon-separated list of pixel-mappers to arrange pixels.")]
        public string LedPixelMapper { get; set; }

        //  -t <seconds>              : Run for these number of seconds, then exit.
        //--led-gpio-mapping=<name> : Name of GPIO mapping used. Default "regular"
        //--led-rows=<rows>         : Panel rows. Typically 8, 16, 32 or 64. (Default: 32).
        //--led-cols=<cols>         : Panel columns. Typically 32 or 64. (Default: 32).
        //--led-chain=<chained>     : Number of daisy-chained panels. (Default: 1).
        //--led-parallel=<parallel> : Parallel chains. range=1..3 (Default: 1).
        
        //--led-pixel-mapper        : Semicolon-separated list of pixel-mappers to arrange pixels.
        //                            Optional params after a colon e.g. "U-mapper;Rotate:90"
        //                            Available: "Rotate", "U-mapper". Default: ""
        //
        //--led-row-addr-type=<0..2>: 0 = default; 1 = AB-addressed panels; 2 = direct row select(Default: 0).
        //--led-show-refresh        : Show refresh rate.
        //--led-inverse             : Switch if your matrix has inverse colors on.
        //--led-rgb-sequence        : Switch if your matrix has led colors swapped (Default: "RGB")
        //--led-no-hardware-pulse   : Don't use hardware pin-pulse generation.
        //--led-slowdown-gpio=<0..2>: Slowdown GPIO. Needed for faster Pis/slower panels (Default: 1).
        //--led-daemon              : Make the process run in the background as daemon.
        //--led-no-drop-privs       : Don't drop privileges from 'root' after initializing the hardware.


    }
    public enum RenderMode
    {
        Console,
        LedMatrix
    }
}
