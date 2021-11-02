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
        static int playerTurn = 1;

        static char MapDigitToChar(int dig)
        {
            switch (dig)
            {
                case 1:
                    return '⬛';
                case 2:
                    return '⃝';
                default:
                    return '□';
            }
        }

        static int previousSelection = 0;
        static int[] currentSelection = new int[2] { 0, 0 };
        static void Render()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    //Console.Write("⃝ "); // ⬛ ☐
                    //Console.Write(map[x, y]);
                    Console.Write($"{MapDigitToChar(map[x, y])}");
                }
                Console.WriteLine();
            }
        }

        static void SetToMap(int[] pos, int c)
        {
            previousSelection = map[pos[0], pos[1]];
            map[pos[0],pos[1]] = c;
        }

        static bool Interact(bool b = false)
        {
            ConsoleKey key = Console.ReadKey().Key;

            if (!b)
                SetToMap(currentSelection, previousSelection);

            switch (key)
            {
                case ConsoleKey.DownArrow:
                    if (currentSelection[0] < 2) currentSelection[0]++;
                    break;
                case ConsoleKey.UpArrow:
                    if (currentSelection[0] > 0) currentSelection[0]--;
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentSelection[1] > 0) currentSelection[1]--;
                    break;
                case ConsoleKey.RightArrow:
                    if (currentSelection[1] < 2) currentSelection[1]++;
                    break;
                case ConsoleKey.Enter:
                    if (previousSelection == 0) // need to work on Enter etc
                        SetToMap(currentSelection, playerTurn);
                    return true;
                default:
                    break;
            }
            SetToMap(currentSelection, playerTurn);
            return false;
        }

        static void Main(string[] args) // set font to SimSun-ExtB or MS Gothic
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            bool test = false;
            while (true)
            {
                Console.WriteLine("Welcome to Noughts and Crosses");
                Render();
                if (Interact(test)) test = true;
                else test = false;

                Console.Clear();
            }
        }
    }
}
