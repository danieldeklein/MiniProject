public class Player
{
    public int CurrentHitPoints;
    public Location? CurrentLocation;
    public Weapon? CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;
    private Random RandomNumberGenerator = new Random();
    public List<Quest> CompletedQuests;
    public Inventory Inv;
    
    public Player(string Name, int MaximumHitPoints)
    {
        CurrentHitPoints = 95;
        CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Inv = new Inventory();
        Inv.AddWeapon(World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD));
        CurrentWeapon = World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD);
        this.Name = Name;
        this.MaximumHitPoints = MaximumHitPoints;
        CompletedQuests = new List<Quest>();
    }

    public Inventory GetInventory() => Inv;

    public void Fight(Monster monster)
    {
        if(monster == null) return;
        if(monster.CurrentHitPoints <= 0)
        {
            Console.WriteLine($"You defeat {monster.Name}!");
            Console.WriteLine(monster.Drop(this));
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            monster.CurrentHitPoints = monster.MaximumHitPoints;
            return;
        }
        if(CurrentHitPoints <= 0)
        {
            Console.WriteLine("You have been defeated!");
            CurrentHitPoints = MaximumHitPoints;
            CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);
            return;
        }
        // Ask player what he wants to do:
        // 1. Attack
        // 2. Run
        string input;
        do
        {
            Console.Clear();
            Console.WriteLine($"You have {CurrentHitPoints} hit points remaining.");
            Console.WriteLine($"The {monster.Name} has {monster.CurrentHitPoints} hit points remaining.");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Run");
            input = Console.ReadLine() ?? "";
            
            if (input == "2")
            {
                return;
            }
        } while (input != "1" && input != "2");

        int damageToMonster = RandomNumberGenerator.Next(0, CurrentWeapon?.maximumDamage ?? 1);
        int damageToPlayer = RandomNumberGenerator.Next(1, monster.MaximumDamage + 1);

        monster.CurrentHitPoints -= damageToMonster;
        Console.WriteLine($"You hit the {monster.Name} for {damageToMonster} points of damage.");
        Thread.Sleep(500);

        CurrentHitPoints = Math.Max(0, CurrentHitPoints - damageToPlayer);
        Console.WriteLine($"The {monster.Name} hit you for {damageToPlayer} points of damage.");
        Thread.Sleep(1000);

        // Recursive call
        Fight(monster);
    }
    
    public void DisplayStats()
    {
        // Menu:
        /* 
            1. View Inventory
            2. View Quest progress
            3. Go back
        */
        Console.Clear();
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Hit Points: {CurrentHitPoints}/{MaximumHitPoints}");
        Console.WriteLine($"Weapon equiped: {CurrentWeapon?.Name}");
        Console.WriteLine($"Current Location: {CurrentLocation?.Name}");
        Console.WriteLine("\n");
        Console.WriteLine("1. View Inventory");
        Console.WriteLine("2. View Quest progress");

        string input = Console.ReadLine() ?? "";
        if(input == "1")
        {
            Inv.DisplayInventory();
        }
        else if(input == "2")
        {
            DisplayQuests();
        }
        else if(input == "3")
        {
            return; // Add return to move menu
        }
        else
        {
            DisplayStats();
        }
    } 

    public void DisplayQuests()
    {
        Console.Clear();
        Console.WriteLine("Completed Quests:");
        foreach (Quest quest in CompletedQuests)
        {
            Console.WriteLine($"{quest.Name}");
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }

    public string HealDamage(int hitPointsToHeal)
    {
        CurrentHitPoints = Math.Min(CurrentHitPoints + hitPointsToHeal, MaximumHitPoints);
        return $"You have been healed for {hitPointsToHeal} hit points.";
    }


}