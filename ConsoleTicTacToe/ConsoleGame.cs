using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace ConsoleTicTacToe
{
    public class ConsoleGame:Game, Displayable
    {
        static void Main(string[] args)
        {
            var game = new ConsoleGame();

            while (true)
            {
                game.Display();
                // take input
                Console.WriteLine("Row:");
                var row = Console.ReadLine();
                Console.WriteLine("Col:");
                var col = Console.ReadLine();
                // make changes
                var l = new Move(game.playerTurn, int.Parse(row), int.Parse(col));

                var result = game.playerMove(l);
                if (result == gameOutCome.Cats)
                {
                    Console.WriteLine("It's a cats game!");
                }
                else if (result == gameOutCome.Win)
                {
                    Console.WriteLine("You've won!");
                }
            }

            //
        }
        static string printCell(Cell cell)
        {
            switch (cell)
            {
                case Cell.Empty:
                    return " ";
                case Cell.O:
                    return "O";
                case Cell.X:
                    return "X";

            }
            return " ";
        }
        public void Display()
        {
            Console.WriteLine($"Player {this.playerTurn}, it's your turn");
            for(int i = 0;i < 3; i++)
            {
                Console.WriteLine($"{printCell(gameboard.getValue(new Location(i, 0)))} |" +
                    $" {printCell(gameboard.getValue(new Location(i, 1)))} |" +
                    $" {printCell(gameboard.getValue(new Location(i, 2)))}");
            }
        }
    }
}
