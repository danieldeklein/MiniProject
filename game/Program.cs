using System;

class Program
{
    static void Main(string[] args)
    {
        // Start the game
        Location? currentLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Console.WriteLine("Welcome to the Text-Based Game!");
        Console.WriteLine("Your starting position is: " + currentLocation?.Name);
        GameLoop(currentLocation);
    }

    static void GameLoop(Location? currentLocation)
    {
        bool continueGame = true;

        while (continueGame)
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
                    Travel(currentLocation);
                    break;
                case 2:
                    // See stats logic
                    break;
                case 3:
                    // Fight logic
                    break;
                case 4:
                    continueGame = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void Travel(Location? currentLocation)
    {
        PrintMap(currentLocation);

        Console.WriteLine("Enter a direction (north, east, south, west) to move:");
        string direction = Console.ReadLine()?.ToLower();

        // Move to the next location based on the direction
        switch (direction)
        {
            case "north":
                if (currentLocation?.LocationToNorth != null)
                {
                    currentLocation = currentLocation.LocationToNorth;
                    Console.WriteLine("You moved to: " + currentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            case "east":
                if (currentLocation?.LocationToEast != null)
                {
                    currentLocation = currentLocation.LocationToEast;
                    Console.WriteLine("You moved to: " + currentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            case "south":
                if (currentLocation?.LocationToSouth != null)
                {
                    currentLocation = currentLocation.LocationToSouth;
                    Console.WriteLine("You moved to: " + currentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            case "west":
                if (currentLocation?.LocationToWest != null)
                {
                    currentLocation = currentLocation.LocationToWest;
                    Console.WriteLine("You moved to: " + currentLocation?.Name);
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

        GameLoop(currentLocation);
    }

    static void PrintMap(Location? currentLocation)
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
        Console.WriteLine("Current Location: " + currentLocation?.Name);
        Console.WriteLine("Description: " + currentLocation?.Description);
        Console.WriteLine();
    }
}