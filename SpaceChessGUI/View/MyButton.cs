using System.Drawing; // You need this to use the Image class
using System.Windows.Forms;

namespace SpaceChessGUI
{
    public class MyButton : Button
    {
        private int row, column;
        bool hasPlayer = false;
        public static Bitmap computerShip = resources.ComputerShip;
        public static Bitmap playerShip = resources.PlayerShip;
        public static Bitmap cornerBlock = resources.cornerBlock;
        public MyButton()
        {
                Size = new Size(150,150);
        }
        public void setHasPlayer(bool hasPlayer)
        {
            this.hasPlayer = hasPlayer;
            this.Enabled = hasPlayer;
        }
        public void setBackgroundColor()
        {
            this.BackColor = Color.White;
        }
        public void setLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }       
        public void setBackgroundImage(Bitmap image)
        {
            this.BackgroundImage = image;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void setColumn(int column)
        {
            this.column = column;
        }

        public void setRow(int row)
        {
            this.row = row;
        }
        public int getRow() { return row; }
        public int getColumn() { return column; }
        public bool getHasPlayer() { return hasPlayer; }
        public Bitmap getComputerShip() { return computerShip; }
        public Bitmap getPlayerShip() { return playerShip; }
    }
}
