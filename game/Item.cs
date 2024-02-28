public class Item
{

    public string Name;
    public int Amount;
    public int ID;
    public Func<string>? Use;

    public Item(int ID, int Amount)
    {
        Name = GetName(ID);
        this.ID = ID;
        this.Amount = Amount;
    }

    private string GetName(int ID)
    {
        switch (ID)
        {
            case 1:
                return "Health Potion";
            case 2:
                return "Rat Tail";
            case 3:
                return "Snake Skin";
            case 4:
                return "Spider Silk";
            default:
                return "Unknown";
        }
    }

}