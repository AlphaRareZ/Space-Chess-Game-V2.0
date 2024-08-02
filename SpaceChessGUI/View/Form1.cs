using System;
using System.Windows.Forms;

namespace SpaceChessGUI.View
{
    public partial class Form1 : Form
    {
        private readonly Controller _controller = new Controller();

        public Form1()
        {
            InitializeComponent();
            _controller.SetForm(this);
            _controller.UpdateViewGrid();
        }

        private void MyButtonClick(object sender, EventArgs e)
        {
            MyButton x = (MyButton)sender;
            _controller.PlayerMadeMove(x.getRow(), x.getColumn());
        }
    }
}