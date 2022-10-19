using WinFormsApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Board game = new Board();
        Button[] buttons = new Button[9];
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            game = new Board();

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += handleButtonclick;
                buttons[i].Tag = i;
            }
        }

        private void handleButtonclick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int gameSquareNumber = (int)clickedButton.Tag;
            game.Grid[gameSquareNumber] = 1;
            updateBoard();

            if (game.checkForWinner() == 1)
            {
                MessageBox.Show("WIN");
                disableAllButtons();
            }
            else if (game.isBoardFull() == true)
            {
                MessageBox.Show("DRAW");
                disableAllButtons();
            }
            else
            {
                //computer queue
                computerChoose();
            }
        }

        private void disableAllButtons()
        {
            foreach (var item in buttons)
            {
                item.Enabled = false;
            }
        }

        private void computerChoose()
        {
            //the computer selects a random number
            int computerTurn = rand.Next(9);
            //get a random step from the computer
            while (computerTurn == -1 || game.Grid[computerTurn] != 0)
            {
                computerTurn = rand.Next(9);
            }
            game.Grid[computerTurn] = 2;
            updateBoard();
            //winner check, table is full
            if (game.checkForWinner() == 2)
            {
                MessageBox.Show("DEFEAT");
                disableAllButtons();
            }
            else if (game.isBoardFull() == true)
            {
                MessageBox.Show("DRAW");
                disableAllButtons();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateBoard();
        }

        private void updateBoard()
        {
            for (int i = 0; i < game.Grid.Length; i++)
            {
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text = "";
                    buttons[i].Enabled = true;
                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                    buttons[i].Enabled = false;
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "О";
                    buttons[i].Enabled = false;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            game = new Board();
            enableAllButtons();
        }

        private void enableAllButtons()
        {
            foreach (var item in buttons)
            {
                item.Enabled = true;
            }
            updateBoard();
        }
    }
}

