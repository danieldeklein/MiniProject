using System.Collections;
using System.Net.Quic;

class Program
{
    static void Main(string[] args)
    {
        
        // Start the game
        Location? currentLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Console.WriteLine("Welcome to the Text-Based Game!");
        Console.WriteLine("Your starting position is: " + currentLocation.Name);

        // Game loop
        while (true)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Travel");
            Console.WriteLine("2. See stats");
            Console.WriteLine("3. fight");
            Console.WriteLine("4. Exit");
            int eersteKeuze = Convert.ToInt32(Console.ReadLine());
            if (eersteKeuze == 1)
            {
                PrintMap(currentLocation);

                Console.WriteLine("Enter a direction (north, east, south, west) to move:");
                string direction = Console.ReadLine().ToLower();

                // Move to the next location based on the direction
                switch (direction)
                {
                    case "north":
                        if (currentLocation.LocationToNorth != null)
                        {
                            currentLocation = currentLocation.LocationToNorth;
                            Console.WriteLine("You moved to: " + currentLocation.Name);
                        }
                        else
                        {
                            Console.WriteLine("You cannot move in that direction.");
                        }
                        break;
                    case "east":
                        if (currentLocation.LocationToEast != null)
                        {
                            currentLocation = currentLocation.LocationToEast;
                            Console.WriteLine("You moved to: " + currentLocation.Name);
                        }
                        else
                        {
                            Console.WriteLine("You cannot move in that direction.");
                        }
                        break;
                    case "south":
                        if (currentLocation.LocationToSouth != null)
                        {
                            currentLocation = currentLocation.LocationToSouth;
                            Console.WriteLine("You moved to: " + currentLocation.Name);
                        }
                        else
                        {
                            Console.WriteLine("You cannot move in that direction.");
                        }
                        break;
                    case "west":
                        if (currentLocation.LocationToWest != null)
                        {
                            currentLocation = currentLocation.LocationToWest;
                            Console.WriteLine("You moved to: " + currentLocation.Name);
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
            }
            // if (eersteKeuze == 2)
            // {
            //     Console.WriteLine("Player Stats:");
            //     Console.WriteLine("Name: " + player.Name);
            //     Console.WriteLine("Current Hit Points: " + player.CurrentHitPoints);
            //     Console.WriteLine("Maximum Hit Points: " + player.MaximumHitPoints);
            //     Console.WriteLine("Current Location: " + player.CurrentLocation?.Name);
            //     Console.WriteLine("Current Weapon: " + player.CurrentWeapon?.Name);
            // }
            if (eersteKeuze == 3)
            {
                break;
            }
            if (eersteKeuze == 4)
            {
                Environment.Exit(0);
            }
        }
    }

    static void PrintMap(Location currentLocation)
    {
        Console.WriteLine("  P");
        Console.WriteLine("  A");
        Console.WriteLine("VFTGBS");
        Console.WriteLine("  H");
        Console.WriteLine();
        Console.WriteLine("Current Location: " + currentLocation.Name);
        Console.WriteLine("Description: " + currentLocation.Description);
        Console.WriteLine();
    }
}