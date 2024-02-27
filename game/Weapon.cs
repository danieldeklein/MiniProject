using System.ComponentModel;

public class Weapon
{
    public int ID;
    public int maximumDamage;
    public string Name;

    public Weapon(int ID, string Name, int maximumDamage)
    {
        this.ID = ID;
        this.Name = Name;
        this.maximumDamage = maximumDamage;
    }
}
