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
                    return '●';
                case 2:
                    return '❌';
                case 3:
                    return '■'; // for selection
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

        static bool Check(out int winner)
        {
            // horizontal check
            for (int x = 0; x < 3; x++)
            {
                int current = 0;
                bool changed = false;
                for (int y = 0; y < 3; y++)
                {
                    if (changed) continue;
                    if (y==0) current = map[x, y];
                    if (current == 0 || (current != map[x, y])) changed = true;
                }
                if (!changed)
                {
                    winner = current;
                    return true;
                }
            }
            // vertical check
            for (int x = 0; x < 3; x++)
            {
                int current = 0;
                bool changed = false;
                for (int y = 0; y < 3; y++)
                {
                    if (changed) continue;
                    if (y == 0) current = map[y,x];
                    if (current == 0 || (current != map[y,x])) changed = true;
                }
                if (!changed)
                {
                    winner = current;
                    return true;
                }
            }
            // diagonal check 1
            {
                int current = 0;
                bool changed = false;
                for (int x = 0; x < 3; x++)
                {
                    if (changed) continue;
                    if (x == 0) current = map[x, x];
                    if (current == 0 || (current != map[x, x])) changed = true;
                }
                if (!changed)
                {
                    winner = current;
                    return true;
                }
            }
            // diagonal check 2
            {
                int current = 0;
                bool changed = false;
                for (int x = 2; x >= 0; x--)
                {
                    if (changed) continue;
                    if (x == 2) current = map[2 - x, x];
                    if (current == 0 || (current != map[2 - x, x])) changed = true;
                }
                if (!changed)
                {
                    winner = current;
                    return true;
                }
            }

            winner = 0;
            return false;
        }

        static void SetToMap(int[] pos, int c)
        {
            previousSelection = map[pos[0], pos[1]];
            map[pos[0],pos[1]] = c;
        }

        static bool Interact(bool enterPressed = false)
        {
            ConsoleKey key = Console.ReadKey().Key;

            if (!enterPressed)
                SetToMap(currentSelection, previousSelection);
            //else
            //    SetToMap(currentSelection, playerTurn);

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
                    if (map[currentSelection[0], currentSelection[1]] == 0)
                    { // need to fix this 
                        SetToMap(currentSelection, playerTurn);
                        return true;
                    }
                    break;
                default:
                    break;
            }
            SetToMap(currentSelection, playerTurn);

            return false;
        }

        static void Main(string[] args) // set font to SimSun-ExtB or MS Gothic
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            int winner;
            bool enterPressed = false;
            while (true)
            {
                Console.WriteLine("Welcome to Noughts and Crosses");
                Render();
                if (enterPressed = Interact(enterPressed))
                {
                    playerTurn = playerTurn == 1 ? 2 : 1;
                    if (Check(out winner)) break;
                }

                Console.Clear();
            }
            Console.WriteLine($"{(winner == 1 ? "nought" : "cross")} is the winner!!!!!");
        }
    }
}
