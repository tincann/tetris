using Tetris.Game.Constants;

namespace Tetris.Game.Controls
{
    public interface ITetrisController
    {
        GameAction GetKeyState();
    }
}
