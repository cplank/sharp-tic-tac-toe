using System;

namespace TicTacToe
{
    public class Board
    {
        Cell[,] Spaces;

        public Board()
        {
            Spaces = new Cell[,] 
            { { Cell.Empty, Cell.Empty, Cell.Empty },
                { Cell.Empty, Cell.Empty, Cell.Empty },
                { Cell.Empty, Cell.Empty, Cell.Empty } };
        }

        public Cell getValue(Location location)
        {
            return Spaces[location.row,location.col];
        }
        // overload getValue, for those who just like numbers or whatever
        public Cell getValue(int row, int col)
        {
            return Spaces[row, col];
        }

        public void setValue(Location location, Token token)
        {
            Spaces[location.row, location.col] =(Cell) token;

        }
        public bool IsBoardFull()
        {
            for(var i = 0; i < Spaces.GetLength(0); i++)
            {
               for(var j=0; j <Spaces.GetLength(1); j++)
                {
                    if(Spaces[i,j] == Cell.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static bool isCellEqual(Cell cell, Token token)
        {
            if(cell == Cell.X && token == Token.X)
            {
                return true;
            }
            if(cell == Cell.O && token == Token.O)
            {
                return true;
            }
            return false;
        }
        bool CheckLine(Cell[] line, Token token){
            foreach (var cell in line)
            {
                if(!isCellEqual(cell, token))
                {
                    return false;
                }
            }
            return true;
        }
        
        public bool CheckWin(Token token)
        {
            var diag1 = new Cell[] { Spaces[0, 0], Spaces[1, 1], Spaces[2, 2] };
            var diag2 = new Cell[] { Spaces[0, 2], Spaces[1, 1], Spaces[2, 0] };
            for (var i = 0; i < Spaces.Length; i++)
            {
                var row = new Cell[] { Spaces[i, 0], Spaces[i, 1], Spaces[i, 2] };
                var col = new Cell[] { Spaces[0, i], Spaces[1, i], Spaces[2, i] };
                if (CheckLine(col, token))
                {
                    return true;
                } 
                if (CheckLine(row, token))
                {
                    return true;
                }
            }

            if(CheckLine(diag1, token))
            {
                return true;
            }

            if(CheckLine(diag2, token))
            {
                return true;
            }
            return false;
            
        }
    }
}