using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        Token playerTurn;
        Dictionary<Token, int> winCount;         
        Board gameboard;

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

        public void playerMove(Token token, Location move)
        {
            if (IsValidMove(move))
            {
                gameboard.setValue(move, token);

                if (IsCatsGame())
                {
                    //probably tell the user its a cats game?
                } else if (gameboard.CheckWin(token)){
                    winCount[token]++;
                    this.gameboard = new Board();
                    playerTurn = Token.X;
                        //congrats! player token has won                    
                } else
                {
                    playerTurn = playerTurn == Token.X ? Token.O : Token.X;
                }     
           

            }

        }


    }
}
