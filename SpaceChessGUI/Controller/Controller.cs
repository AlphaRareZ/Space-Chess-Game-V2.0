using SpaceChessGUI.Model;
using System;
using System.Media;
using System.Windows.Forms;

namespace SpaceChessGUI
{
    public class Controller
    {
        Form1 myForm;
        GameModel model = new GameModel();
       
        public void setForm(Form1 form)
        {
            this.myForm = form;
        }
        
        public bool playerMadeMove(int i,int j)
        {
            bool playerMoved = model.PlayerMadeMove(i, j);
            if (playerMoved) playMoveSound();
            model.MakeComputerMove();
            updateViewGrid();
            checkWinner();
            return playerMoved;
        }
        private void playMoveSound()
        {
            SoundPlayer player = new SoundPlayer(resources.move);
            player.Play();
        }
        private void checkWinner()
        {
            int winner = winnerType();
            if (winner == (int)Winner.PLAYER) // player
            {
                MessageBox.Show("Congrats Baby U Won");
            }
            else if (winner == (int)Winner.COMPUTER)
            {
                playLoseSound();
                MessageBox.Show("أنا الكبير يا بابا 😎☝");
            }
        }

        private void playLoseSound()
        {
            SoundPlayer player = new SoundPlayer(resources.LoseSound);
            player.Play();
        }

        public int getGridSize()
        {
            return model.GetGridSize();
        }
        public int winnerType()
        {
            return model.WinnerType();
        }

        // 
        private void invertEnabledButtons()
        {
            foreach (MyButton myButton in myForm.GetButtons())
            {
                if (myButton.getHasPlayer())
                {
                    myButton.Enabled = !myButton.Enabled;
                }
            }
        }
        public void updateViewGrid()
        {

            char[,] gameGrid = model.GetGameGrid();

            for (int i = 0; i < model.GetGridSize(); i++)
            {
                for (int j = 0; j < model.GetGridSize(); j++)
                {
                    char currentCell = gameGrid[i, j];
                    if (currentCell == 'X')
                    {
                        myForm.GetButtons()[i, j].setBackgroundImage(MyButton.playerShip);
                        myForm.GetButtons()[i, j].setHasPlayer(true);
                    }
                    else if (currentCell == 'O')
                    {
                        myForm.GetButtons()[i, j].setBackgroundImage(MyButton.computerShip);
                        myForm.GetButtons()[i, j].setHasPlayer(false);

                    }
                    else if (currentCell == '#')
                    {
                        myForm.GetButtons()[i, j].setBackgroundImage(MyButton.block);
                        myForm.GetButtons()[i, j].setHasPlayer(false);
                    }
                    else
                    {
                        myForm.GetButtons()[i, j].BackgroundImage = null;
                        myForm.GetButtons()[i, j].setHasPlayer(false);

                    }

                }
            }

        }

    }
}

