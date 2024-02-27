namespace game;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Create the map
        string[,] map = new string[4, 6]
        {
            { " ", " ", "P", " ", " ", " "},
            { " ", " ", "A", " ", " ", " "},
            { "V", "F", "T", "G", "B", "S"},
            { " ", " ", "H", " ", " ", " "}
        };

        // Set the player's starting position
        int playerX = 3;
        int playerY = 6;

        // Print the map
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

        // Get user input for movement
        Console.WriteLine("Choose a direction to move (up, down, left, right):");
        string direction = Console.ReadLine();

        // Update player's position based on user input
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

        // Print the updated map with player's new position
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
        if (direction == "up" && playerX > 0)
        {
            playerX--;
        }
        else if (direction == "down" && playerX < 3) // Adjusted condition to playerX < 3
        {
            playerX++;
        }
        else if (direction == "left" && playerY > 0)
        {
            playerY--;
        }
        else if (direction == "right" && playerY < 5) // Adjusted condition to playerY < 5
        {
            playerY++;
        }

    }
    
}
