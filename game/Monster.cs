public class Monster{

    public int CurrentHitPoints;
    public int ID;
    public int MaximumDamage;
    public int MaximumHitPoints;
    public string Name;
    public List<Item> LootItems;
    public List<Weapon> LootWeapons;

    public Monster(int ID, string Name, int MaximumDamage, int CurrentHitPoints, int MaximumHitPoints)
    {
        this.ID = ID;
        this.Name = Name;
        this.CurrentHitPoints = CurrentHitPoints;
        this.MaximumDamage = MaximumDamage;
        this.MaximumHitPoints = MaximumHitPoints;
        LootItems = new List<Item>();
        LootWeapons = new List<Weapon>();
    }

    public void DisplayMonsterInfo()
    {
        Console.WriteLine($"Monster: {this.Name}");
        Console.WriteLine($"Maximum Damage: {this.MaximumDamage}");
        Console.WriteLine($"Current Hit Points: {this.CurrentHitPoints}");
        Console.WriteLine($"Maximum Hit Points: {this.MaximumHitPoints}");
    }

    public string Drop(Player p)
    {
        Random rand = new Random();
        if(rand.NextDouble() > 0.5)
        {
            // Add random Item
            if(LootItems.Count > 0)
            {
                int choice = rand.Next(LootItems.Count);
                p.GetInventory().AddItemToInventory(LootItems[choice]);
                return $"You found {LootItems[choice].Name}!";
            }
            else if(LootWeapons.Count > 0)
            {
                // Add random Weapon
                int choice = rand.Next(LootWeapons.Count);
                p.GetInventory().AddWeapon(LootWeapons[choice]);
                return $"You found {LootWeapons[choice].Name}!";
            }
        }
        else
        {
            // Add random Weapon
            if(LootWeapons.Count > 0)
            {
                int choice = rand.Next(LootWeapons.Count);
                p.GetInventory().AddWeapon(LootWeapons[choice]);
                return $"You found {LootWeapons[choice].Name}!";
            }
            else if(LootItems.Count > 0)
            {
                // Add random Item
                int choice = rand.Next(LootItems.Count);
                p.GetInventory().AddItemToInventory(LootItems[choice]);
                return $"You found {LootItems[choice].Name}!";
            }
        }

        return "";
    }

}