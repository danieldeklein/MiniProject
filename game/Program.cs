class Program
{
    
    static void Main(string[] args)
    {
        // Start the game
        Console.Clear();
        Console.WriteLine("Welcome to the Text-Based Game!");
        Console.WriteLine("Your quests to win:");
        Console.WriteLine("- Kill 3 rats");
        Console.WriteLine("- Kill 2 snakes");
        Console.WriteLine("- Kill 2 spiders");
        Console.WriteLine("Your starting position is: " + World.player.CurrentLocation?.Name);
        Item item = new Item(World.ITEM_ID_HEALING_POTION, 1);
        item.Use = () => World.player.HealDamage(5);
        Item banaan = new Item(World.ITEM_ID_BANANA, 5);
        banaan.Use = () => World.player.HealDamage(2);
        World.player.GetInventory().AddItemToInventory(item);
        World.player.GetInventory().AddItemToInventory(banaan);
        GameLoop();
    }

    static void GameLoop()
    {
        if(CheckQuests())
        {
            AskEnd();
        }
        Console.Clear();
        Console.WriteLine("Current location: " + World.player.CurrentLocation?.Name);
        Console.WriteLine("Description: " + World.player.CurrentLocation?.Description);
        Console.WriteLine();
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Travel");
        Console.WriteLine("2. See stats");
        string monsterName = World.player.CurrentLocation?.MonsterLivingHere?.Name ?? "| Unavailable";
        Console.WriteLine("3. Fight " + monsterName);
        Console.WriteLine("4. Exit");
        string eersteKeuze = Console.ReadLine();

        switch (eersteKeuze)
        {
            case "1":
                Travel();
                GameLoop();
                break;
            case "2":
                // See stats logic
                World.player.DisplayStats();
                break;
            case "3":
                // Fight logic
                World.player.Fight(World.player.CurrentLocation.MonsterLivingHere);
                GameLoop();
                break;
            case "4":
                Console.WriteLine("Thanks for playing!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                GameLoop();
                break;
        }
        GameLoop();
    }

    static void Travel()
    {
        Console.Clear();
        PrintMap();

        Console.WriteLine("Enter a direction (north, east, south, west) to move:");
        Console.WriteLine("Or type 'cancel' to go back.");
        string direction = (Console.ReadLine() ?? "").ToLower();

        // Move to the next location based on the direction
        switch (direction)
        {
            case "north":
            case "n":
                if (World.player.CurrentLocation?.LocationToNorth != null)
                {
                    World.player.CurrentLocation = World.player.CurrentLocation.LocationToNorth;
                    Console.WriteLine("You moved to: " + World.player.CurrentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                    Travel();
                }
                break;
            case "east":
            case "e":
                if (World.player.CurrentLocation?.LocationToEast != null)
                {
                    World.player.CurrentLocation = World.player.CurrentLocation.LocationToEast;
                    Console.WriteLine("You moved to: " + World.player.CurrentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                    Travel();
                }
                break;
            case "south":
            case "s":
                if (World.player.CurrentLocation?.LocationToSouth != null)
                {
                    World.player.CurrentLocation = World.player.CurrentLocation.LocationToSouth;
                    Console.WriteLine("You moved to: " + World.player.CurrentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                    Travel();
                }
                break;
            case "west":
            case "w":
                if (World.player.CurrentLocation?.LocationToWest != null)
                {
                    World.player.CurrentLocation = World.player.CurrentLocation.LocationToWest;
                    Console.WriteLine("You moved to: " + World.player.CurrentLocation?.Name);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                    Travel();
                }
                break;
            case "cancel":
                GameLoop();
                break;
            default:
                Console.WriteLine("Invalid direction. Please try again.");
                Travel();
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

    static bool CheckQuests()
    {
        if(World.player.RatKills >= 3)
        {
            World.QuestByID(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN).Completed = true;
        }
        if(World.player.SnakeKills >= 2)
        {
            World.QuestByID(World.QUEST_ID_CLEAR_FARMERS_FIELD).Completed = true;
        }
        if(World.player.SpiderKills >= 2)
        {
            World.QuestByID(World.QUEST_ID_COLLECT_SPIDER_SILK).Completed = true;
        }
        
        foreach(Quest q in World.Quests)
        {
            bool AlreadyAdded = false;
            foreach(Quest cq in World.player.CompletedQuests)
            {
                if(cq.ID == q.ID) AlreadyAdded = true;;
            }
            if(q.Completed && !AlreadyAdded)
            {
                World.player.CompletedQuests.Add(q);
            }
        }

        return World.player.CompletedQuests.Count >= 3;
    }

    static void AskEnd()
    {
        Console.WriteLine("You finished the game, well done!");
        Console.WriteLine("Do you want to quit(q) or play more (p)");
        string choice = Console.ReadLine() ?? "";
        switch(choice)
        {
            case "q":
                Console.WriteLine("Thanks for playing!");
                Environment.Exit(0);
                break;
            case "p":
                return;
            default:
                AskEnd();
                break;
        }
    }

}