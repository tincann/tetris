# Tetris

Supports different rendering implementations, such as drawing directly to the command line or to a RGB led matrix.

![](docs/tetris.gif)

Runs on a Raspberry PI 3 through the `librgbmatrix` library.

### Instructions
The program must be started with the `RenderMode` parameter.
> ./Tetris.App --RenderMode Console

or

> ./Tetris.App --RenderMode LedMatrix

See [Tetris.App/Program.cs#L57](Tetris.App/Program.cs#L57) for more command line options.
