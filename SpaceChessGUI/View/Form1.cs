using SpaceChessGUI;
using System;
using System.Windows.Forms;

namespace SpaceChessGUI
{
    public partial class Form1 : Form
    {
        Controller controller = new Controller();
        public Form1()
        {
            InitializeComponent();
            controller.setForm(this);
            controller.updateViewGrid();

        }
        private void MyButtonClick(object sender, EventArgs e)
        {
            MyButton x = (MyButton)sender;
            bool playerMoved = controller.playerMadeMove(x.getRow(), x.getColumn());
        }

    }
}
