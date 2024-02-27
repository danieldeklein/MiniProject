public class Monster{

    public int CurrentHitPoints;
    public int ID;
    public int MaximumDamage;
    public int MaximumHitPoints;
    public string Name;

    public Monster(int ID, string Name, int CurrentHitPoints, int MaximumDamage, int MaximumHitPoints)
    {
        this.ID = ID;
        this.Name = Name;
        this.CurrentHitPoints = CurrentHitPoints;
        this.MaximumDamage = MaximumDamage;
        this.MaximumHitPoints = MaximumHitPoints;
    }

}