class Program
{

    static void Main(string[] args)
    {
        // Start the game
        Console.WriteLine("Welcome to the Text-Based Game!");
        Console.WriteLine("Your starting position is: " + World.player.CurrentLocation?.Name);
        GameLoop();
    }

    static void GameLoop()
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Travel");
        Console.WriteLine("2. See stats");
        Console.WriteLine("3. fight");
        Console.WriteLine("4. Exit");
        int eersteKeuze = Convert.ToInt32(Console.ReadLine());

        switch (eersteKeuze)
        {
            case 1:
                Travel();
                GameLoop();
                break;
            case 2:
                // See stats logic
                World.player.DisplayStats();
                GameLoop();
                break;
            case 3:
                // Fight logic
                World.player.Fight(World.player.CurrentLocation.MonsterLivingHere);
                GameLoop();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                GameLoop();
                break;
        }
    }

    static void Travel()
    {
        PrintMap();

        Console.WriteLine("Enter a direction (north, east, south, west) to move:");
        string direction = (Console.ReadLine() ?? "").ToLower();

        // Move to the next location based on the direction
        switch (direction)
        {
            case "north":
                if (World.player.CurrentLocation?.LocationToNorth != null)
                {
                    World.player.CurrentLocation = World.player.CurrentLocation.LocationToNorth;
                    Console.WriteLine("You moved to: " + World.player.CurrentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            case "east":
                if (World.player.CurrentLocation?.LocationToEast != null)
                {
                    World.player.CurrentLocation = World.player.CurrentLocation.LocationToEast;
                    Console.WriteLine("You moved to: " + World.player.CurrentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            case "south":
                if (World.player.CurrentLocation?.LocationToSouth != null)
                {
                    World.player.CurrentLocation = World.player.CurrentLocation.LocationToSouth;
                    Console.WriteLine("You moved to: " + World.player.CurrentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            case "west":
                if (World.player.CurrentLocation?.LocationToWest != null)
                {
                    World.player.CurrentLocation = World.player.CurrentLocation.LocationToWest;
                    Console.WriteLine("You moved to: " + World.player.CurrentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            default:
                Console.WriteLine("Invalid direction. Please try again.");
                break;
        }

        GameLoop();
    }

    static void PrintMap()
    {
        Console.WriteLine("H: Your house");
        Console.WriteLine("T: Town square");
        Console.WriteLine("F: Farmer");
        Console.WriteLine("V: Famer's field");
        Console.WriteLine("A: Alchemist's hut");
        Console.WriteLine("P: Alchemist's garden");
        Console.WriteLine("G: Guard post");
        Console.WriteLine("B: Bridge");
        Console.WriteLine("S: Spider field");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Map:");
        Console.WriteLine("  P");
        Console.WriteLine("  A");
        Console.WriteLine("VFTGBS");
        Console.WriteLine("  H");
        Console.WriteLine();
        Console.WriteLine("Current Location: " + World.player.CurrentLocation?.Name);
        Console.WriteLine("Description: " + World.player.CurrentLocation?.Description);
        Console.WriteLine();
    }
}