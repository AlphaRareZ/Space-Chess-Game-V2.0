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
        private void PlayLoseSound()
        {
            SoundPlayer player = new SoundPlayer(resources.LoseSound);
            player.Play();
        }

        private void PlayMoveSound()
        {
            SoundPlayer player = new SoundPlayer(resources.moveSound);
            player.Play();
        }
        private void PlayNewGameSound()
        {
            SoundPlayer player = new SoundPlayer(resources.newGame);
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
            // 0 -> None, 1 -> Player, 2 -> Computer
            var winner = WinnerType();
            switch (winner)
            {
                
                case (int)Winner.Player:
                    GameEndDialogs((int)Winner.Player);
                    break;
                case (int)Winner.Computer:
                    PlayLoseSound();
                    GameEndDialogs((int)Winner.Computer);
                    break;
                case (int)Winner.None:
                    break;
            }
        }
        private void GameEndDialogs(int winner)
        {
            // no winner
            if(winner == 0) return;
            // winner = 1 -> player
            // winner = 2 -> computer
            if(winner == 1)
                MessageBox.Show(@"يابن اللعيبة كسبتني 😳", "Result");
            else 
                MessageBox.Show(@"أنا الكبير يا بابا 😎☝", "Result");

            // check if player wants to play again
            DialogResult res = MessageBox.Show(@"تلعب تاني ؟", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(res == DialogResult.Yes)
            {
                _model.ResetGame();
                // Play the new game sound to silence losing sound 😜
                PlayNewGameSound();
                // update view grid after resetting the game
                UpdateViewGrid();
            }
            else if(res == DialogResult.No)
            {
                _myForm.Close();
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
                        _myForm.GetButtons()[i, j].setBackgroundImage(MyButton.cornerBlock);
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