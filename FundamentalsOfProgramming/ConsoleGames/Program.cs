using System;

namespace ConsoleGames
{
    class Program
    {
        static int[,] map = new int[,]{
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };

        static void Render()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Console.Write("□ "); // ⬛
                    //Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.WriteLine("Welcome to Noughts and Crosses");
            Render();
        }
    }
}
