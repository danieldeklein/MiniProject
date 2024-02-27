using System;

namespace MiniProject.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create locations
            Location home = new Location(1, "Your House", "Your starting position", null, null);
            Location townSquare = new Location(2, "Town Square", "A bustling square in the center of town", null, null);
            Location farmer = new Location(3, "Farmer", "A friendly farmer's house", null, null);
            Location farmerField = new Location(4, "Farmer's Field", "A vast field with crops", null, null);
            Location alchemistHut = new Location(5, "Alchemist's Hut", "A mysterious hut filled with potions", null, null);
            Location alchemistGarden = new Location(6, "Alchemist's Garden", "A beautiful garden with rare herbs", null, null);
            Location guardPost = new Location(7, "Guard Post", "A heavily guarded post", null, null);
            Location bridge = new Location(8, "Bridge", "A sturdy bridge over a river", null, null);
            Location spiderForest = new Location(9, "Spider Forest", "A dark forest infested with spiders", null, null);

            // Set location connections
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToWest = farmer;
            townSquare.LocationToEast = guardPost;

            farmer.LocationToEast = farmerField;
            farmer.LocationToEast = townSquare;

            farmerField.LocationToWest = farmer;

            alchemistHut.LocationToNorth = alchemistGarden;
            alchemistHut.LocationToSouth = townSquare;

            alchemistGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = townSquare;

            bridge.LocationToEast = spiderForest;
            bridge.LocationToSouth = guardPost;

            spiderForest.LocationToWest = bridge;


            // Start the game
            Location currentLocation = home;
            Console.WriteLine("Welcome to the Text-Based Game!");
            Console.WriteLine("Your starting position is: " + currentLocation.Name);

            // Game loop
            while (true)
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
}
