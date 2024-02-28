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

}