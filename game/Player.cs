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
        CurrentHitPoints = 100;
        CurrentLocation = World.LocationByID(1);
        CurrentWeapon = World.WeaponByID(1);
        this.Name = Name;
        this.MaximumHitPoints = MaximumHitPoints;
        CompletedQuests = new List<Quest>();
        Inv = new Inventory();
    }

    public Inventory GetInventory() => Inv;

    public void Fight(Monster monster)
    {
        if (monster == null)
        {
            return;
        }

        while (CurrentHitPoints > 0 && monster.CurrentHitPoints > 0)
        {
            int damageToMonster = RandomNumberGenerator.Next(0, CurrentWeapon?.maximumDamage ?? 1);
            int damageToPlayer = RandomNumberGenerator.Next(0, monster.MaximumDamage);

            monster.CurrentHitPoints -= damageToMonster;
            Console.WriteLine($"You hit the {monster.Name} for {damageToMonster} points of damage.");
            Thread.Sleep(500);

            if (monster.CurrentHitPoints <= 0)
            {
                CurrentHitPoints = Math.Max(0, CurrentHitPoints - damageToPlayer);
                Console.WriteLine($"The {monster.Name} hit you for {damageToPlayer} points of damage.");
                Thread.Sleep(500);
                Console.WriteLine($"The {monster.Name} has been defeated!");
                if (CurrentHitPoints <= 0)
                {
                    Console.WriteLine("You have been defeated!");
                }
                else
                {
                    Console.WriteLine($"You have {CurrentHitPoints} hit points remaining.");
                }
            }
        
            monster.CurrentHitPoints = monster.MaximumHitPoints;
        }

    }
    
    public void DisplayStats()
    {
        // Menu:
        /* 
            1. View Inventory
            2. View Quest progress
            3. Go back
        */
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Hit Points: {CurrentHitPoints}");
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
        Console.WriteLine("Completed Quests:");
        foreach (Quest quest in CompletedQuests)
        {
            Console.WriteLine($"{quest.Name}");
        }
    }


}