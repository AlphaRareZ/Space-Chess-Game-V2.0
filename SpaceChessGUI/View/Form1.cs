using System;
using System.Windows.Forms;

namespace SpaceChessGUI.View
{
    public partial class Form1 : Form
    {
        private readonly Controller _controller = new Controller();

        public Form1()
        {
            // initialize the Client Size
            InitializeComponent();
            // initialize buttons in client view
            InitializeCustomComponents();

            _controller.SetForm(this);
            _controller.UpdateViewGrid();
        }

        private void MyButtonClick(object sender, EventArgs e)
        {
            MyButton x = (MyButton)sender;
            _controller.PlayerMadeMove(x.getRow(), x.getColumn());
        }

        private void InitializeCustomComponents()
        {
            int size = _controller.GetGridSize();
            buttons = new MyButton[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    MyButton button = new MyButton();
                    button.setLocation(j * button.Width, i * button.Height);
                    button.setRow(i);
                    button.setColumn(j);
                    button.Enabled = false;
                    button.Click += MyButtonClick;

                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
        }
    }
}