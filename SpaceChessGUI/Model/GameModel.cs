using SpaceChessGUI.Model.Wrapper;

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
            return GameWrapper.GetGameGrid();
        }

        public int WinnerType()
        {
            return GameWrapper.winnerType();
        }
        public void ResetGame()
        {
            GameWrapper.resetGame();
        }
    }
}