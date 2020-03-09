using System;
using System.Collections.Generic;

namespace TicTacToe
{
        public class Game
    {
        public Token playerTurn;
        Dictionary<Token, int> winCount;         
        protected Board gameboard;
        
        public Game()
        {
            playerTurn = Token.X;
            winCount = new Dictionary<Token, int>() { { Token.X, 0 },{ Token.O, 0 } };
            gameboard = new Board();
            
        }
        bool IsValidMove(Location location)
        {
            //if (gameboard[location])
            if (gameboard.getValue(location) != Cell.Empty) {
                return false;
            } else
            {
                return true;
            }

        }

        bool IsCatsGame()
        {            
            {
                if(gameboard.IsBoardFull() && !gameboard.CheckWin(Token.O) && !gameboard.CheckWin(Token.X))
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public gameOutCome playerMove(Move move)
        {
            if (IsValidMove(move))
            {
                gameboard.setValue(move);                

                if (IsCatsGame())
                {
                    gameboard = new Board();
                    return gameOutCome.Cats;

                } else if (gameboard.CheckWin(move.token)){
                    winCount[move.token]++;
                    gameboard = new Board();
                    playerTurn = Token.X;
                    return gameOutCome.Win;                   
                } else
                {
                    playerTurn = playerTurn == Token.X ? Token.O : Token.X;
                    return gameOutCome.Continue;
                }            

            }
            return gameOutCome.Continue;
        }
    }
}
