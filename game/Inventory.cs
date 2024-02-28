public class Inventory
{

    public List<Item> InventoryItems;
    public List<Weapon> InventoryWeapons;

    public Inventory()
    {
        InventoryItems = new List<Item>();
        InventoryWeapons = new List<Weapon>();
    }

    public void AddItemToInventory(Item item)
    {
        foreach (Item inventoryItem in InventoryItems)
        {
            if (inventoryItem.ID == item.ID)
            {
                inventoryItem.Amount += item.Amount;
                return;
            }
        }
        InventoryItems.Add(item);
    }

    public void AddWeapon(Weapon weapon)
    {
        InventoryWeapons.Add(weapon);
    }

    public void RemoveItem(Item item)
    {
        foreach (Item inventoryItem in InventoryItems)
        {
            if (inventoryItem.ID == item.ID)
            {
                inventoryItem.Amount -= item.Amount;
                if (inventoryItem.Amount <= 0)
                {
                    InventoryItems.Remove(inventoryItem);
                }
                return;
            }
        }
    }

    public void RemoveWeapon(Weapon weapon)
    {
        try
        {
            InventoryWeapons.Remove(weapon);
        }
        catch
        {
            return;
        }
    }

    public void DisplayInventory()
    {
        Console.Clear();
        Console.WriteLine("[ Inventory ]");
        Console.WriteLine("Items:");
        foreach (Item item in InventoryItems)
        {
            Console.WriteLine($"- {item.Name} x{item.Amount}");
        }
        Console.WriteLine("Weapons:");
        foreach (Weapon weapon in InventoryWeapons)
        {
            Console.WriteLine($"- {weapon.Name}");
        }
        Console.WriteLine();
        Console.WriteLine("1. Equip Weapon");
        Console.WriteLine("2. Use Item");
        Console.WriteLine("3. Go back");
        string choice = Console.ReadLine() ?? "";
        // Add option to equip weapon, use item, or go back
        switch (choice)
        {
            case "1":
                EquipWeapon();
                break;
            case "2":
                UseItem();
                break;
            case "3":
                return;
            default:
                DisplayInventory();
                break;
        }
    }

    public void EquipWeapon()
    {
        Console.WriteLine("0. Go back");
        for(int i = 0; i < InventoryWeapons.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {InventoryWeapons[i].Name}");
        }
        string input = Console.ReadLine() ?? "";
        try
        {
            int index = Convert.ToInt32(input);
            if(index == 0)
            {
                return;
            }
            else
            {
                World.player.CurrentWeapon = InventoryWeapons[index - 1];
            }
        }
        catch
        {
            EquipWeapon();
        }

    }

    public void UseItem()
    {
        List<Item> usableItems = new List<Item>();
        foreach (Item item in InventoryItems)
        {
            if (item.Use != null)
            {
                usableItems.Add(item);
            }
        }

        Console.WriteLine("0. Go back");
        for (int i = 0; i < usableItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {usableItems[i].Name}");
        }
        string input = Console.ReadLine() ?? "";
        try
        {
            int index = Convert.ToInt32(input);
            if (index == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine(usableItems[index - 1]?.Use());
                Thread.Sleep(1000);
                
                usableItems[index - 1].Amount--;
                if (usableItems[index - 1].Amount <= 0)
                {
                    InventoryItems.Remove(usableItems[index - 1]);
                }
            }
        }
        catch
        {
            UseItem();
        }

    }

}