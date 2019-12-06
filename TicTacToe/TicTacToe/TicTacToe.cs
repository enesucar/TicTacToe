using System;

namespace TicTacToe
{
    class TicTacToeGame
    {
        private char?[,] matrix;
        private char next;
        private int xPoint;
        private int oPoint;

        public int XPoint { get { return this.xPoint; } set { this.xPoint = value; } }
        public int OPoint { get { return this.oPoint; } set { this.oPoint = value; } }
        public char Next { get { return this.next; } set { this.next = value; } }

        public TicTacToeGame()
        {
            this.matrix = new char?[3,3];
            this.XPoint = 0;
            this.OPoint = 0;
            this.Next = 'X';
        } // Constructor

        public void Reset() // Reset game
        {
            this.matrix = new char?[3, 3];
            this.next = 'X';
        }

        public string Update()
        {
            int winx = 0;
            int wino = 0;
            int isnotnull = 0;
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[j, i] == 'X')
                        winx += 1;

                    if (matrix[j, i] == 'O')
                        wino += 1;
                }

                if (winx == 3)
                    return "truexVertical";
                else if (wino == 3)
                    return "trueoVertical";

                winx = 0;
                wino = 0;
            } // VERTICAL
            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == 'X')
                        winx += 1;

                    if (matrix[i, j] == 'O')
                        wino += 1;
                }

                if (winx == 3)
                    return "truexHorizontal";
                else if (wino == 3)
                    return "trueoHorizontal";

                winx = 0;
                wino = 0;
            } // HORIZANTAL
            for (int i = 0; i < 3; i++) // capraz
            {

                if (matrix[i, i] == 'X')
                    winx += 1;

                if (matrix[i, i] == 'O')
                    wino += 1;
            } // CROSS

            if (winx == 3)
                return "truexCross";
            else if (wino == 3)
                return "trueoCross";

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (matrix[i, j] != null)
                        isnotnull++;

            if (isnotnull == 9)
                return "draw";
            return "false";
        }  // Game play update

        public void SetMatrix(int x, int y, char type)
        {
            this.matrix[x, y] = type;
        } // Fill matrix
    }
}