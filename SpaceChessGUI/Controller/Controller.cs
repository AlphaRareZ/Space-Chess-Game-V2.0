using System.Media;
using System.Windows.Forms;
using SpaceChessGUI.Model;
using SpaceChessGUI.View;

namespace SpaceChessGUI
{
    public class Controller
    {
        private Form1 _myForm;
        private readonly GameModel _model = new GameModel();

        
        // sound functions
        private static void PlayLoseSound()
        {
            SoundPlayer player = new SoundPlayer(resources.LoseSound);
            player.Play();
        }

        private static void PlayMoveSound()
        {
            SoundPlayer player = new SoundPlayer(resources.move);
            player.Play();
        }
        
        
        // getters
        public int GetGridSize()
        {
            return _model.GetGridSize();
        }

        private int WinnerType()
        {
            return _model.WinnerType();
        }

        
        // setters
        public void SetForm(Form1 form)
        {
            _myForm = form;
        }
        
        
        // InGame Functions
        public bool PlayerMadeMove(int i, int j)
        {
            bool playerMoved = _model.PlayerMadeMove(i, j);
            if (playerMoved) PlayMoveSound();
            _model.MakeComputerMove();
            UpdateViewGrid();
            CheckWinner();
            return playerMoved;
        }
        
        private void CheckWinner()
        {
            var winner = WinnerType();
            switch (winner)
            {
                // player
                case (int)Winner.Player:
                    MessageBox.Show(@"Congrats Baby U Won");
                    break;
                case (int)Winner.Computer:
                    PlayLoseSound();
                    MessageBox.Show(@"أنا الكبير يا بابا 😎☝");
                    break;
            }
        }
        
        // View Functions
        public void UpdateViewGrid()
        {
            char[,] gameGrid = _model.GetGameGrid();

            for (int i = 0; i < _model.GetGridSize(); i++)
            {
                for (int j = 0; j < _model.GetGridSize(); j++)
                {
                    char currentCell = gameGrid[i, j];
                    if (currentCell == 'X')
                    {
                        _myForm.GetButtons()[i, j].setBackgroundImage(MyButton.playerShip);
                        _myForm.GetButtons()[i, j].setHasPlayer(true);
                    }
                    else if (currentCell == 'O')
                    {
                        _myForm.GetButtons()[i, j].setBackgroundImage(MyButton.computerShip);
                        _myForm.GetButtons()[i, j].setHasPlayer(false);
                    }
                    else if (currentCell == '#')
                    {
                        _myForm.GetButtons()[i, j].setBackgroundImage(MyButton.block);
                        _myForm.GetButtons()[i, j].setHasPlayer(false);
                    }
                    else
                    {
                        _myForm.GetButtons()[i, j].BackgroundImage = null;
                        _myForm.GetButtons()[i, j].setHasPlayer(false);
                    }
                }
            }
        }
    }
}