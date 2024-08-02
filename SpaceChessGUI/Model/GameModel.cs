
namespace SpaceChessGUI.Model
{
    internal class GameModel
    {
        public bool PlayerMadeMove(int i, int j)
        {
            return GameWrapper.playerMadeMove(i, j);
        }

        public bool MakeComputerMove()
        {
            return GameWrapper.makeComputerMove();
        }

        public int GetGridSize()
        {
            return GameWrapper.getGridSize();
        }

        public char[,] GetGameGrid()
        {
            return GameWrapper.getGameGrid();
        }

        public int WinnerType()
        {
            return GameWrapper.winnerType();
        }
    }
}
