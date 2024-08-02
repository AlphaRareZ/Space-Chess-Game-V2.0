using SpaceChessGUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceChessGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        MyButton[,] buttons;
        public MyButton[,] GetButtons() { return buttons; }
        private void InitializeComponent()
        {
            this.ClientSize = new System.Drawing.Size(750, 750);

            int size = controller.getGridSize();
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


        #endregion
    }


}