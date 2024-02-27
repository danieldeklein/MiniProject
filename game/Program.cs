<<<<<<< HEAD
<<<<<<< HEAD
﻿namespace game;
=======
﻿﻿namespace game;
>>>>>>> c1b3e8dbe3b2ce08198b4148f46ba2e85a429d76

class Program
{
    static void Main(string[] args)
    {
<<<<<<< HEAD
        Console.WriteLine($"{World.Weapons[0].Name} {World.Weapons[0].maximumDamage}");
    }

=======
        Console.WriteLine("Hello, World!");

        string[,] map = new string[4, 6]
        {
            { " ", " ", "P", " ", " ", " "},
            { " ", " ", "A", " ", " ", " "},
            { "V", "F", "T", "G", "B", "S"},
            { " ", " ", "H", " ", " ", " "}
        };

        World.QuestByID(1).DisplayQuestInfo();

        int playerX = 3;
        int playerY = 6;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (i == playerX && j == playerY)
                {
                    Console.Write("H");
                }
                else
                {
                    Console.Write(map[i, j]);
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine("Choose a direction to move (up, down, left, right):");
        string? direction = Console.ReadLine();

        if (direction == "up" && playerX > 0)
        {
            playerX--;
        }
        else if (direction == "down" && playerX < 4)
        {
            playerX++;
        }
        else if (direction == "left" && playerY > 0)
        {
            playerY--;
        }
        else if (direction == "right" && playerY < 6)
        {
            playerY++;
        }

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (i == playerX && j == playerY)
                {
                    Console.Write("H");
                }
                else
                {
                    Console.Write(map[i, j]);
                }
            }
            Console.WriteLine();
        }
    }
    
>>>>>>> c1b3e8dbe3b2ce08198b4148f46ba2e85a429d76
}
=======
﻿using System;

namespace game
{
    class Program
    {
        public int playerY = 5;
        public int playerX = 3;
        static void Main(string[] args)
        {
            World.QuestByID(1).DisplayQuestInfo();
            Console.WriteLine("Your current location is: " + locatie);
            Console.WriteLine("  P  ");
            Console.WriteLine("  A  ");
            Console.WriteLine("VFTGBS");
            Console.WriteLine("  H  ");

            Console.WriteLine("Which direction do you want to go? (north/south/east/west)");
            string direction = Console.ReadLine();

            // TODO: Handle the user's chosen direction and update the game accordingly

            Console.WriteLine("You chose to go " + direction + "."); // Placeholder output

        }
    }
}
>>>>>>> 54d58b5b04a4bd4450c1a316e98a3115a4b1e992
