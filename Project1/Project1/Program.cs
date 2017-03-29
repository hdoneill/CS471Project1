using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[6, 7];

            fillBoard(board);

            bool temp = checkFullBoard(board);

            int playerMove = getPlayerMove();
            while (playerMove != 8)
            {
                char[,] newBoard = addMove(playerMove, board);
                fillBoard(newBoard);
                playerMove = getPlayerMove();
            }

            string end = Console.ReadLine();
        }


        static int getPlayerMove()
        {
            Console.WriteLine("Player please choose a column (1 - 7) to play, or 8 to quit:");
            int playerMove = Convert.ToInt16(Console.ReadLine());
            if (playerMove == 8)
                Environment.Exit(1);
            if (playerMove < 1 || playerMove > 7)
                Console.WriteLine("Not a valid move.");
            return playerMove - 1;
        }

        static char[,] addMove(int playerMove, char[,] board)
        {
           int i = 0;
            if (board[0, playerMove] != '*')
            {
                Console.WriteLine("That column is full!");
                return board;
            }

           while(i < 6 && board[i, playerMove] == '*' )
           {
                i++;
           }

           board[i - 1, playerMove] = 'X';
           return board;
        }


        // TEMP CODE TAKEN CHANGE
        static void fillBoard(char[,] board)
        {
            int rows = 6, columns = 7, i, j;

            for (i = 0; i < rows; i++)
            {
                Console.Write("|");
                for (j = 0; j < columns; j++)
                {
                    if (board[i, j] != 'X' && board[i, j] != 'O')
                        board[i, j] = '*';

                    Console.Write(board[i, j]);

                }

                Console.Write("| \n");
            }

        }

        static bool checkFullBoard(char[,] board)
        {
            int checkFull = 0;
            for(int i = 0; i < 7; i++)
            {
                if (board[0, i] == 'X' || board[0, i] == 'O')
                    checkFull++;
            }

            if (checkFull == 6)
                return true;
            else
                return false;
        }
    }
}
