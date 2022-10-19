using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Board

    {
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public int[] Grid
        {
            get; set;
        }
        public Board()
        {
            Grid = new int[9];
            //initialize the board
            //set all sauqares to empty
            for (int i = 0; i < 9; i++)
            {
                Grid[i] = 0;
            }
        }

        public bool isBoardFull()
        {
            bool isFull = true;
            for (int i = 0; i < Grid.Length; i++)
            {
                if (Grid[i] == 0)
                {
                    isFull = false;
                }
            }
            return isFull;
        }

        public int checkForWinner()
        {
            if (Grid[0] == Grid[1] && Grid[1] == Grid[2])
            {
                //top row match
                return Grid[0];
            }
            if (Grid[3] == Grid[4] && Grid[4] == Grid[5])
            {
                //middle row match
                return Grid[3];
            }
            if (Grid[6] == Grid[7] && Grid[7] == Grid[8])
            {
                //bottom row match
                return Grid[6];
            }
            if (Grid[0] == Grid[3] && Grid[3] == Grid[6])
            {
                //first col match
                return Grid[0];
            }
            if (Grid[1] == Grid[4] && Grid[4] == Grid[7])
            {
                //second col match
                return Grid[1];
            }
            if (Grid[2] == Grid[5] && Grid[5] == Grid[8])
            {
                //third col match
                return Grid[2];
            }
            if (Grid[0] == Grid[4] && Grid[4] == Grid[8])
            {
                //first diagonal match
                return Grid[0];
            }
            if (Grid[2] == Grid[4] && Grid[4] == Grid[6])
            {
                //second diagonal match
                return Grid[2];
            }
            return 0;
        }
    }
}

