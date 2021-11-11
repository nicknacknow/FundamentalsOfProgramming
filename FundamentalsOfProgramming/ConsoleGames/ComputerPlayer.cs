using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGames
{
    class ComputerPlayer
    {
        // get list of all possible winnable places, e.g. first row could be 101, bot would place in 2nd place so its 111 ------- returns all horizontal, vertical and diagonal positions
        // there are 8 places you can win

        static int[,] GetHorizontalData(int[,] map)
        {
            int[,] horizontalData = new int[,]{
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            return horizontalData;
        }

        static int[,] GetVerticalData(int[,] map)
        {
            int[,] verticalData = new int[,]{
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            return verticalData;
        }

        static int[,] GetDiagonalData(int[,] map)
        {
            int[,] diagonalData = new int[,]{
                {0, 0, 0},
                {0, 0, 0}
            };

            // diagonal 1

            for (int x = 0; x < 3; x++)
            {
                diagonalData[0,x] = map[x, x];
            }

            return diagonalData;
        }
        static int[,] GetMapData(int[,] map)
        {
            int[,] mapdata = new int[,]{
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };



            return mapdata;
        }
        
        static bool GetPlacePosition(int[,] map, out int[] placePos)
        {

            placePos = new int[2] { 0, 0 };
            return false;
        }

    }
}
