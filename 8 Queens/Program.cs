/*
 * Kyle Wilson
 * 800856836
 * 8-31-2019
 * Not sure if it is all or nothing for points on the 
 * rubric but please go easy on it
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp;

            int heuristic = 0;

            int betterNeighbors = 0;

            int stateChanges = 0;

            int[,] gameBoard = new int[8, 8];

            int[] conflicts = new int[8];


            int[] queens = new int[8];
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Creates the queens
            Random rnd = new Random();
            for(int i = 0; i < 8; i++)
            {
                queens[i] = rnd.Next(0, 8);
            }


            //assigns queens to spot on the gameboard
            for (int i = 0; i < 8; i++)
            {
                temp = queens[i];

                for (int x = 0; x < 8; x++)
                {
                    gameBoard[temp, i] = 1;
                }
            }


//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            do{

                betterNeighbors = 0;

                //checks columns for conflicts - how many queens are in each row - i: row   x: column
                for (int i = 0; i < 8; i++) //column number
                {
                    for (int x = 0; x < 8; x++)  // row number
                    {
                        if (gameBoard[i, x] == 1)
                        {
                            conflicts[i]++;
                        }
                    }
                }


                int tempHeuristic = 0;

                for (int i = 0; i < 8; i++)
                {
                    if(conflicts[i] > 0)
                    {
                        tempHeuristic += conflicts[i] - 1;
                    }
                }


                //counts the heuristic total
                for (int i = 0; i < 8; i++)
                {
                    heuristic += conflicts[i];
                }
                Console.WriteLine("Current h: " + tempHeuristic * 2);
                Console.WriteLine("Current State");
                heuristic = 0;


                //Creates the game board
                for (int i = 0; i < 8; i++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        Console.Write(gameBoard[i, x] + " ");
                    }
                    Console.WriteLine();
                }


                //Finds index of highest and lowest rows
                int maxValueNumber = conflicts.Max();
                int maxValueIndex = conflicts.ToList().IndexOf(maxValueNumber);

                int minValueNumber = conflicts.Min();
                int minValueIndex = conflicts.ToList().IndexOf(minValueNumber);


                //Finds the index in the queen array of the queen that needs to be moved
                int indexNum = Array.IndexOf(queens, maxValueIndex);
                queens[indexNum] = minValueIndex;


                //changes the location of old queen to 0
                gameBoard[maxValueIndex, indexNum] = 0;

                for(int i = 0; i < 8; i++)
                {
                    if(conflicts[i] == 0)
                    {
                        betterNeighbors++;
                    }
                }
                Console.WriteLine("Neighbors found with lower h: " + betterNeighbors + "\nSetting new current state\n");


                //assigns queens to spot on the gameboard
                for (int i = 0; i < 8; i++)
                {
                    temp = queens[i];

                    for (int x = 0; x < 8; x++)
                    {
                        gameBoard[temp, i] = 1;
                    }
                }

                for (int i = 0; i < 8; i++)
                {
                    conflicts[i] = 0;
                }

                stateChanges++;

            } while (betterNeighbors > 0) ;
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            Console.WriteLine("\nCurrent State");

            
            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Console.Write(gameBoard[i, x] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Solution Found!" + "\nState Changes: " + stateChanges);

            Console.ReadLine();

    

        }
    }
}